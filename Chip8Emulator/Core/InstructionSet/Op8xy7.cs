﻿namespace Chip8Emulator.Core.InstructionSet
{
    // 8xy7 - SUBN Vx, Vy
    public class Op8xy7 : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF00F) == 0x8007;

        public override void Run(ushort opcode, Chip8System system)
        {
            var registerIndex1 = (byte) ((opcode & 0x0F00) >> 8);
            var registerIndex2 = (byte) ((opcode & 0x00F0) >> 4);
            system.Cpu.V[0xF] = (byte) (system.Cpu.V[registerIndex2] > system.Cpu.V[registerIndex1] ? 1 : 0);
            system.Cpu.V[registerIndex1] = (byte) (system.Cpu.V[registerIndex2] - system.Cpu.V[registerIndex1]);
            system.Cpu.PC += 2;
        }
    }
}