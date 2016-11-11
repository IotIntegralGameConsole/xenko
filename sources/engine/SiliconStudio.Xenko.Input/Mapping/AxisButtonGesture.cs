﻿// Copyright (c) 2016 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using System;
using SiliconStudio.Core;

namespace SiliconStudio.Xenko.Input.Mapping
{
    /// <summary>
    /// A button gesture generated from an <see cref="IAxisGesture"/>, with a customizable threshold
    /// </summary>
    [DataContract]
    public class AxisButtonGesture : InputGesture, IButtonGesture
    {
        /// <summary>
        /// The threshold value the axis needs to reach in order to trigger a button press
        /// </summary>
        public float Threshold = 0.5f;

        private IAxisGesture axis;

        /// <summary>
        /// The axis that triggers this button
        /// </summary>
        public IAxisGesture Axis
        {
            get { return axis; }
            set
            {
                UpdateChild(axis, value);
                axis = value;
            }
        }
        
        [DataMemberIgnore]
        public bool Button => Axis?.Axis > Threshold;

        public override void Reset(TimeSpan elapsedTime)
        {
            axis?.Reset(elapsedTime);
        }

        protected bool Equals(AxisButtonGesture other)
        {
            return Threshold.Equals(other.Threshold);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AxisButtonGesture)obj);
        }

        public override int GetHashCode()
        {
            return Threshold.GetHashCode();
        }
    }
}