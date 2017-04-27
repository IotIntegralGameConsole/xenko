// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
#if SILICONSTUDIO_PLATFORM_ANDROID
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression.Zip;
using System.Linq;
using System.Text.RegularExpressions;
using SiliconStudio.Core.Serialization;

namespace SiliconStudio.Core.IO
{
    /// <summary>
    /// A file system implementation for IVirtualFileProvider.
    /// </summary>
    public class ZipFileSystemProvider : VirtualFileProviderBase
    {
        /// <summary>
        /// Base path of this provider (every path will be relative to this one).
        /// </summary>
        private readonly ZipFile zipFile;
        private readonly Dictionary<string, ZipFileEntry> zipFileEntries = new Dictionary<string, ZipFileEntry>();

        public ZipFile ZipFile
        {
            get { return zipFile; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemProvider" /> class with the given base path.
        /// </summary>
        /// <param name="rootPath">The root path of this provider.</param>
        /// <param name="localBasePath">The path to a local directory where this instance will load the files from.</param>
        public ZipFileSystemProvider(string rootPath, string zipFilePath) : base(rootPath)
        {
            zipFile = new ZipFile(zipFilePath);
            zipFileEntries = zipFile.GetAllEntries()
                .Where(x => x.FilenameInZip.StartsWith("assets/data/"))
                .ToDictionary(x => x.FilenameInZip
                    .Replace("assets/data/", string.Empty),
                    x => x);
        }

        public override Stream OpenStream(string url, VirtualFileMode mode, VirtualFileAccess access, VirtualFileShare share = VirtualFileShare.Read, StreamFlags streamType = StreamFlags.None)
        {
            ZipFileEntry zipFileEntry;
            if (!zipFileEntries.TryGetValue(url, out zipFileEntry))
                throw new FileNotFoundException("File not found inside ZIP archive.");

            if (mode != VirtualFileMode.Open || access != VirtualFileAccess.Read)
                throw new UnauthorizedAccessException("ZIP archive are read-only.");

            lock (zipFile)
            {
                if (zipFileEntry.Method == Compression.Store)
                {
                    // Open a VirtualFileStream on top of Zip FileStream
                    return new VirtualFileStream(new FileStream(zipFileEntry.ZipFileName, FileMode.Open, FileAccess.Read), zipFileEntry.FileOffset, zipFileEntry.FileOffset + zipFileEntry.FileSize);
                }

                // Decompress it into a MemoryStream
                var buffer = new byte[zipFileEntry.FileSize];
                zipFile.ExtractFile(zipFileEntry, buffer);
                return new MemoryStream(buffer);
            }
        }

        public override bool DirectoryExists(string url)
        {
            if(url == null)
                throw new ArgumentNullException("url");

            // ensure that the provided path ends by a slash
            if (!url.EndsWith("/"))
                url += "/";

            return zipFileEntries.Any(x => x.Key.StartsWith(url));
        }

        public override bool FileExists(string url)
        {
            return zipFileEntries.ContainsKey(url);
        }

        public override long FileSize(string url)
        {
            ZipFileEntry zipFileEntry;
            if (!zipFileEntries.TryGetValue(url, out zipFileEntry))
                throw new FileNotFoundException("File not found inside ZIP archive.");

            return zipFileEntry.FileSize;
        }

        public override string[] ListFiles(string url, string searchPattern, VirtualSearchOption searchOption)
        {
            url = Regex.Escape(url);
            searchPattern = Regex.Escape(searchPattern).Replace(@"\*", "[^/]*").Replace(@"\?", "[^/]");
            var recursivePattern = searchOption == VirtualSearchOption.AllDirectories ? "(.*/)*" : "/?";
            var regex = new Regex("^" + url + recursivePattern + searchPattern + "$");

            return zipFileEntries.Keys.Where(x => regex.IsMatch(x)).ToArray();
        }
    }
}
#endif
