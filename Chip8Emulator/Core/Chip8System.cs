using System.IO;

namespace Chip8Emulator.Core
{
    public class Chip8System
    {
        public byte DelayTimer { get; set; }
        public byte SoundTimer { get; set; }

        public Cpu Cpu { get; private set; }
        public Stack Stack { get; private set; }
        public Input Input { get; private set; }
        public Memory Memory { get; private set; }
        public GraphicMemory GraphicMemory { get; private set; }

        public Chip8System()
        {
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
            Cpu.Step();
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