using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chip8Emulator.Core;
using Chip8Emulator.Core.HardwareInterfaces;
using OpenTK.Input;

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
            _system.LoadRom(@"Games\PONG2");
        }

        public void Refresh(GraphicMemory graphicMemory)
        {
            _graphicMemory = graphicMemory;
            Render = true;
        }

        public void BindKeyboardEvents(Input input) => _input = input;

        public void Beep() => Task.Run(() => Console.Beep());

        protected override void OnPreRenderFrame() => _system.Step();

        protected override void OnKeyEvent(Key key, bool pressed)
        {
            var keys = new List<Key>
            {
                Key.Number1, Key.Number2, Key.Number3, Key.Number4,
                Key.Q, Key.W, Key.E, Key.R,
                Key.A, Key.S, Key.D, Key.F,
                Key.Z, Key.X, Key.C, Key.V
            };
            var index = keys.IndexOf(key);
            if (index > -1)
            {
                _input[index] = pressed;
            }
        }

        protected override void DrawFrame()
        {
            for (var x = 0; x < 64; x++)
            {
                for (var y = 0; y < 32; y++)
                {
                    if (_graphicMemory[x + y * 64] == 1)
                    {
                        DrawPixel(x, y);
                    }
                }
            }
            Render = false;
        }
    }
}