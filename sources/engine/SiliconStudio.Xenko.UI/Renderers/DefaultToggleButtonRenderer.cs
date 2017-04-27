// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.

using System;

using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Xenko.Graphics;
using SiliconStudio.Xenko.UI.Controls;

namespace SiliconStudio.Xenko.UI.Renderers
{
    /// <summary>
    /// The default renderer for <see cref="ToggleButton"/>.
    /// </summary>
    internal class DefaultToggleButtonRenderer : ElementRenderer
    {
        public DefaultToggleButtonRenderer(IServiceRegistry services)
            : base(services)
        {
        }

        public override void RenderColor(UIElement element, UIRenderingContext context)
        {
            base.RenderColor(element, context);

            var toggleButton = (ToggleButton)element;
            var sprite = GetToggleStateImage(toggleButton);
            if (sprite?.Texture == null)
                return;
            
            var color = toggleButton.RenderOpacity * Color.White;
            Batch.DrawImage(sprite.Texture, ref element.WorldMatrixInternal, ref sprite.RegionInternal, ref element.RenderSizeInternal, ref sprite.BordersInternal, ref color, context.DepthBias, sprite.Orientation);
        }

        private static Sprite GetToggleStateImage(ToggleButton toggleButton)
        {
            switch (toggleButton.State)
            {
                case ToggleState.Checked:
                    return toggleButton.CheckedImage?.GetSprite();
                case ToggleState.Indeterminate:
                    return toggleButton.IndeterminateImage?.GetSprite();
                case ToggleState.UnChecked:
                    return toggleButton.UncheckedImage?.GetSprite();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
