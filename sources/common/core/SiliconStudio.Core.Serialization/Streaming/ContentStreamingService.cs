// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using SiliconStudio.Core.Extensions;

namespace SiliconStudio.Core.Streaming
{
    /// <summary>
    /// Streamable resources content management service.
    /// </summary>
    public class ContentStreamingService : IDisposable
    {
        private readonly Dictionary<int, ContentStorage> containers = new Dictionary<int, ContentStorage>();

        /// <summary>
        /// The unused data chunks lifetime.
        /// </summary>
        public TimeSpan UnusedDataChunksLifetime = TimeSpan.FromSeconds(3);
        
        /// <summary>
        /// Gets the storage container.
        /// </summary>
        /// <param name="storageHeader">The storage header.</param>
        /// <returns>Content Storage container.</returns>
        public ContentStorage GetStorage(ref ContentStorageHeader storageHeader)
        {
            ContentStorage result;

            lock (containers)
            {
                int hash = storageHeader.DataUrl.GetHashCode();
                if (!containers.TryGetValue(hash, out result))
                {
                    result = new ContentStorage(this);
                    containers.Add(hash, result);
                }
                result.Init(ref storageHeader);
            }

            Debug.Assert(result != null && result.Url == storageHeader.DataUrl);
            return result;
        }

        /// <summary>
        /// Updates this service.
        /// </summary>
        public void Update()
        {
            lock (containers)
            {
                foreach (var e in containers)
                    e.Value.ReleaseUnusedChunks();
            }
        }

        /// <summary>
        /// Performs resources disposing.
        /// </summary>
        public void Dispose()
        {
            lock (containers)
            {
                containers.ForEach(x => x.Value.ReleaseChunks());
                containers.Clear();
            }
        }

        internal void UnregisterStorage(ContentStorage storage)
        {
            lock (containers)
            {
                containers.Remove(storage.Url.GetHashCode());
            }
        }
    }
}