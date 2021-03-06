// Copyright (c) 2011-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiliconStudio.Xenko.DebugTools.DataStructures
{
    public class ProcessInfo
    {
        public List<FrameInfo> Frames { get; private set; }

        public ProcessInfo()
        {
            Frames = new List<FrameInfo>();
        }

        public ProcessInfo Duplicate()
        {
            ProcessInfo duplicate = new ProcessInfo();

            Frames.ForEach(item => duplicate.Frames.Add(item.Duplicate()));

            return duplicate;
        }

        public double BeginTime
        {
            get
            {
                if (Frames == null || Frames.Count == 0)
                    return -1.0;
                return Frames[0].BeginTime;
            }
        }

        public double EndTime
        {
            get
            {
                if (Frames == null || Frames.Count == 0)
                    return -1.0;
                return Frames[Frames.Count - 1].EndTime;
            }
        }

        public double TimeLength
        {
            get
            {
                if (Frames == null || Frames.Count == 0)
                    return -1.0;
                return Frames[Frames.Count - 1].EndTime - Frames[0].BeginTime;
            }
        }
    }
}
