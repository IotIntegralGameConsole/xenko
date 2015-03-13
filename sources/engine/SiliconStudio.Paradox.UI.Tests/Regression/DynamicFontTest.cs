﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Threading.Tasks;

using NUnit.Framework;

using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Games;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.Input;
using SiliconStudio.Paradox.UI.Controls;

namespace SiliconStudio.Paradox.UI.Tests.Regression
{
    /// <summary>
    /// Class for dynamic sized text rendering tests.
    /// </summary>
    public class DynamicFontTest : UnitTestGameBase
    {
        private ContentDecorator decorator;
        private TextBlock textBlock;

        public DynamicFontTest()
        {
            CurrentVersion = 2;
        }

        protected override async Task LoadContent()
        {
            await base.LoadContent();

            textBlock = new TextBlock
                {
                    Font = Asset.Load<SpriteFont>("MSMincho10"), 
                    Text = "Simple Text - 簡単な文章。", 
                    TextColor = Color.Black,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    SynchronousCharacterGeneration = true
                };

            decorator = new ContentDecorator
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                BackgroundImage = new UIImage(Asset.Load<Texture>("DumbWhite")),
                Content = textBlock
            };

            SceneUIComponent.RootElement = decorator;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            const float ChangeFactor = 1.1f;
            const float ChangeFactorInverse = 1 / ChangeFactor;

            // change the size of the virtual resolution
            if (Input.IsKeyReleased(Keys.NumPad0))
                SceneUIRenderer.VirtualResolution = new Int3(GraphicsDevice.BackBuffer.Width / 2, GraphicsDevice.BackBuffer.Height / 2, 400);
            if (Input.IsKeyReleased(Keys.NumPad1))
                SceneUIRenderer.VirtualResolution = new Int3(GraphicsDevice.BackBuffer.Width, GraphicsDevice.BackBuffer.Height, 400);
            if (Input.IsKeyReleased(Keys.NumPad2))
                SceneUIRenderer.VirtualResolution = new Int3(2 * GraphicsDevice.BackBuffer.Width, 2 * GraphicsDevice.BackBuffer.Height, 400);
            if (Input.IsKeyReleased(Keys.Right))
                SceneUIRenderer.VirtualResolution = new Int3((int)(ChangeFactor * SceneUIRenderer.VirtualResolution.X), SceneUIRenderer.VirtualResolution.Y, SceneUIRenderer.VirtualResolution.Z);
            if (Input.IsKeyReleased(Keys.Left))
                SceneUIRenderer.VirtualResolution = new Int3((int)(ChangeFactorInverse * SceneUIRenderer.VirtualResolution.X), SceneUIRenderer.VirtualResolution.Y, SceneUIRenderer.VirtualResolution.Z);
            if (Input.IsKeyReleased(Keys.Up))
                SceneUIRenderer.VirtualResolution = new Int3(SceneUIRenderer.VirtualResolution.X, (int)(ChangeFactor * SceneUIRenderer.VirtualResolution.Y), SceneUIRenderer.VirtualResolution.Z);
            if (Input.IsKeyReleased(Keys.Down))
                SceneUIRenderer.VirtualResolution = new Int3(SceneUIRenderer.VirtualResolution.X, (int)(ChangeFactorInverse * SceneUIRenderer.VirtualResolution.Y), SceneUIRenderer.VirtualResolution.Z);

            if (Input.IsKeyReleased(Keys.D1))
                decorator.LocalMatrix = Matrix.Scaling(1);
            if (Input.IsKeyReleased(Keys.D2))
                decorator.LocalMatrix = Matrix.Scaling(1.5f);
            if (Input.IsKeyReleased(Keys.D3))
                decorator.LocalMatrix = Matrix.Scaling(2);
        }

        protected override void RegisterTests()
        {
            base.RegisterTests();
            FrameGameSystem.DrawOrder = -1;
            FrameGameSystem.Draw(DrawTest0).TakeScreenshot();
            FrameGameSystem.Draw(DrawTest1).TakeScreenshot();
            FrameGameSystem.Draw(DrawTest2).TakeScreenshot();
            FrameGameSystem.Draw(DrawTest3).TakeScreenshot();
            FrameGameSystem.Draw(DrawTest4).TakeScreenshot();
            FrameGameSystem.Draw(DrawTest5).TakeScreenshot();
        }

        public void DrawTest0()
        {
            decorator.LocalMatrix = Matrix.Scaling(1);
            textBlock.TextSize = textBlock.Font.Size;
            SceneUIRenderer.VirtualResolution = new Int3(GraphicsDevice.BackBuffer.Width, GraphicsDevice.BackBuffer.Height, 500);
        }

        public void DrawTest1()
        {
            decorator.LocalMatrix = Matrix.Scaling(1);
            textBlock.TextSize = 2*textBlock.Font.Size;
            SceneUIRenderer.VirtualResolution = new Int3(GraphicsDevice.BackBuffer.Width, GraphicsDevice.BackBuffer.Height, 500);
        }

        public void DrawTest2()
        {
            decorator.LocalMatrix = Matrix.Scaling(1);
            textBlock.TextSize = textBlock.Font.Size;
            SceneUIRenderer.VirtualResolution = new Int3(GraphicsDevice.BackBuffer.Width / 2, GraphicsDevice.BackBuffer.Height / 2, 500);
        }

        public void DrawTest3()
        {
            decorator.LocalMatrix = Matrix.Scaling(2);
            textBlock.TextSize = textBlock.Font.Size;
            SceneUIRenderer.VirtualResolution = new Int3(GraphicsDevice.BackBuffer.Width, GraphicsDevice.BackBuffer.Height, 500);
        }

        public void DrawTest4()
        {
            decorator.LocalMatrix = Matrix.Scaling(1);
            textBlock.TextSize = textBlock.Font.Size;
            SceneUIRenderer.VirtualResolution = new Int3(GraphicsDevice.BackBuffer.Width / 2, GraphicsDevice.BackBuffer.Height, 500);
        }

        public void DrawTest5()
        {
            decorator.LocalMatrix = Matrix.Scaling(1);
            textBlock.TextSize = textBlock.Font.Size;
            SceneUIRenderer.VirtualResolution = new Int3(GraphicsDevice.BackBuffer.Width, GraphicsDevice.BackBuffer.Height / 2, 500);
        }

        [Test]
        public void RunDynamicFontTest()
        {
            RunGameTest(new DynamicFontTest());
        }

        /// <summary>
        /// Launch the Image test.
        /// </summary>
        public static void Main()
        {
            using (var game = new DynamicFontTest())
                game.Run();
        }
    }
}