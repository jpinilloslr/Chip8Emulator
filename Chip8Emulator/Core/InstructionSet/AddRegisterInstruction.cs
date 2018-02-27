using System;

namespace Chip8Emulator.Core.InstructionSet
{
    // 8xy4 - ADD Vx, Vy
    public class AddRegisterInstruction : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF00F) == 0x8004;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerIndex1 = (byte)((opcode & 0x0F00) >> 8);
            var registerIndex2 = (byte)((opcode & 0x00F0) >> 4);
            Int32 sum = system.Cpu.V[registerIndex1] + system.Cpu.V[registerIndex2];
            system.Cpu.V[0xF] = (byte)(sum > 255 ? 1 : 0);
            system.Cpu.V[registerIndex1] = (byte)(sum & 0x000000FF);
            system.Cpu.PC += 2;
        }
    }
}