﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using SiliconStudio.Core;

namespace SiliconStudio.Xenko.Graphics
{
    /// <summary>
    /// Specify how to swizzle a vector.
    /// </summary>
    public enum SwizzleMode
    {
        /// <summary>
        /// Take the vector as is.
        /// </summary>
        [Display("Default")]
        None = 0,

        /// <summary>
        /// Take the only the red component of the vector.
        /// </summary>
        [Display("Grayscale (alpha)")]
        RRRR = 1,

        /// <summary>
        /// Reconstructs the Z(B) component from R and G.
        /// </summary>
        [Display("Normal map")]
        NormalMap = 2,

        /// <summary>
        /// Take the only the red component of the vector, but keeps the object opaque
        /// </summary>
        [Display("Grayscale (opaque)")]
        RRR1 = 3,

        /// <summary>
        /// Take the only the x component of the vector.
        /// </summary>
        [Display("Grayscale (alpha)")]
        XXXX = RRRR,
    }
}