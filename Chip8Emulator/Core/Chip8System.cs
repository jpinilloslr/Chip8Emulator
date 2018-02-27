using System;
using System.IO;

namespace Chip8Emulator.Core
{
    public class Chip8System
    {
        private short _delayTimer;
        private short _soundTimer;

        private Cpu _cpu;
        private Stack _stack;
        private Input _input;
        private Memory _memory;
        private GraphicMemory _graphicMemory;        

        public Chip8System()
        {
            Initialize();
        }

        public void Initialize()
        {
            _cpu = new Cpu {PC = 0x200};
            _stack = new Stack();
            _input = new Input();
            _memory = new Memory();
            _graphicMemory = new GraphicMemory();
        }

        public void LoadRom(string fileName)
        {
            var rom = File.ReadAllBytes(fileName);
            for (var i = 0; i < rom.Length; i++)
            {
                _memory[0x200 + i] = rom[i];
            }
        }

        public void Step()
        {
            
        }
    }
}