// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.

using SiliconStudio.Xenko.Rendering;
using SiliconStudio.Xenko.Graphics;

namespace SiliconStudio.Xenko.Rendering.Tessellation
{
    public class TessellationKeys
    {
        /// <summary>
        /// Desired maximum triangle size in screen space during tessellation.
        /// </summary>
        public static readonly ValueParameterKey<float> DesiredTriangleSize = ParameterKeys.NewValue(12.0f);

        /// <summary>
        /// The intensity of the smoothing for PN-based tessellation.
        /// </summary>
        public static readonly ObjectParameterKey<Texture> SmoothingMap = ParameterKeys.NewObject<Texture>();
        public static readonly ValueParameterKey<float> SmoothingValue = ParameterKeys.NewValue<float>(); 
    }
}
