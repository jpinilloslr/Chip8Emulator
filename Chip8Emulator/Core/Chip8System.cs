using System;
using System.Diagnostics;
using System.IO;
using Chip8Emulator.Core.HardwareInterfaces;

namespace Chip8Emulator.Core
{
    public class Chip8System
    {
        private long _ticks;
        private int _instuctions;
        private bool _invalidatedScreen;
        private readonly IScreen _screen;
        private readonly IBuzzer _buzzer;
        private readonly IKeyboard _keyboard;

        public byte DelayTimer { get; set; }
        public byte SoundTimer { get; set; }

        public Cpu Cpu { get; private set; }
        public Stack Stack { get; private set; }
        public Input Input { get; private set; }
        public Memory Memory { get; private set; }
        public GraphicMemory GraphicMemory { get; private set; }

        public Chip8System(IScreen screen, IBuzzer buzzer, IKeyboard keyboard)
        {
            _screen = screen;
            _buzzer = buzzer;
            _keyboard = keyboard;
            Initialize();
        }

        public void Initialize()
        {
            Cpu = new Cpu(this);
            Input = new Input();
            Stack = new Stack();
            Memory = new Memory();
            GraphicMemory = new GraphicMemory();
            LoadSystemFontSet();
            _keyboard.BindKeyboardEvents(Input);
        }

        public void LoadRom(string fileName)
        {
            var rom = File.ReadAllBytes(fileName);
            for (var i = 0; i < rom.Length; i++)
            {
                Memory[0x200 + i] = rom[i];
            }
        }

        public void Step()
        {
            _invalidatedScreen = false;
            if (Cpu.Step())
            {
                ProcessTimers();
                ManageGraphics();
            }
            _instuctions++;
            if (Environment.TickCount - _ticks > 1000)
            {
                _ticks = Environment.TickCount;
                Console.WriteLine($"{_instuctions} inst/s");
                _instuctions = 0;
            }
            
        }

        public void InvalidateScreen() => _invalidatedScreen = true;

        private void ProcessTimers()
        {
            if (DelayTimer > 0)
            {
                DelayTimer--;
            }

            if (SoundTimer > 0)
            {
                SoundTimer--;
                if (SoundTimer == 0)
                {
                    _buzzer.Beep();
                }
            }
        }

        private void ManageGraphics()
        {
            if (_invalidatedScreen)
            {
                _screen.Refresh(GraphicMemory);
            }
        }

        private void LoadSystemFontSet()
        {
            var data = new byte[]
            {
              0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
              0x20, 0x60, 0x20, 0x20, 0x70, // 1
              0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
              0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
              0x90, 0x90, 0xF0, 0x10, 0x10, // 4
              0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
              0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
              0xF0, 0x10, 0x20, 0x40, 0x40, // 7
              0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
              0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
              0xF0, 0x90, 0xF0, 0x90, 0x90, // A
              0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
              0xF0, 0x80, 0x80, 0x80, 0xF0, // C
              0xE0, 0x90, 0x90, 0x90, 0xE0, // D
              0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
              0xF0, 0x80, 0xF0, 0x80, 0x80  // F
            };

            for (var i = 0; i < data.Length; i++)
            {
                Memory[i] = data[i];
            }
        }
    }
}