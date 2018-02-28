using System;
using Chip8Emulator.Core;
using Chip8Emulator.Core.HardwareInterfaces;

namespace Chip8Emulator
{
    public class MainWindow : EmulatorGameWindow, IScreen, IKeyboard, IBuzzer
    {
        private readonly Chip8System _system;
        private GraphicMemory _graphicMemory;
        private Input _input;

        public MainWindow()
        {
            Title = "Chip8Emulator";
            _system = new Chip8System(this, this, this);
            _system.Initialize();
            _system.LoadRom(@"Games\TETRIS");
        }

        public void Refresh(GraphicMemory graphicMemory)
        {
            _graphicMemory = graphicMemory;
            Render = true;
        }

        public void BindKeyboardEvents(Input input) => _input = input;

        public void Beep() => Console.Beep();

        protected override void OnPreRenderFrame() => _system.Step();

        protected override void DrawFrame()
        {
            for (var x = 0; x < 64; x++)
            {
                for (var y = 0; y < 32; y++)
                {
                    var pixel = _graphicMemory[x + y * 64];
                    if (pixel == 1)
                    {
                        DrawPixel(x, y);
                    }
                }
            }
            Render = false;
        }
    }
}