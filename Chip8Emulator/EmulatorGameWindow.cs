﻿using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Chip8Emulator
{
    public abstract class EmulatorGameWindow : GameWindow
    {
        private const int PixelSize = 10;
        protected bool Render { get; set; }

        protected EmulatorGameWindow() : base(640, 320)
        {
            Initialize();
        }

        private void Initialize()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(0, 640, 320, 0, 0, 10);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            RenderFrame += OnRenderFrame;
        }

        private void OnRenderFrame(object sender, FrameEventArgs frameEventArgs)
        {
            OnPreRenderFrame();
            if (Render)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.Begin(PrimitiveType.Quads);
                DrawFrame();
                GL.End();
                GL.Flush();
                SwapBuffers();
            }
        }

        protected abstract void DrawFrame();

        protected abstract void OnPreRenderFrame();

        protected static void DrawPixel(int x, int y)
        {
            var mappedX = x * PixelSize;
            var mappedY = y * PixelSize;
            GL.Vertex2(mappedX, mappedY);
            GL.Vertex2(mappedX, mappedY + PixelSize);
            GL.Vertex2(mappedX + PixelSize, mappedY + PixelSize);
            GL.Vertex2(mappedX + PixelSize, mappedY);
        }
    }
}