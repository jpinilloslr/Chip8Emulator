using System.IO;

namespace Chip8Emulator.Core
{
    public class Chip8System
    {
        public short DelayTimer { get; private set; }
        public short SoundTimer { get; private set; }

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
    }
}