using System;

namespace Chip8Emulator.Core.InstructionSet
{
    // Cxkk - RND Vx, byte
    public class OpCxkk : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF000) == 0xC000;

        public void Run(ushort opcode, Chip8System system)
        {
            var value = (byte)(opcode & 0x00FF);
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            var rand = (byte) new Random().Next(255);
            system.Cpu.V[registerIndex] = (byte)(rand & value);
            system.Cpu.PC += 2;
        }
    }
}