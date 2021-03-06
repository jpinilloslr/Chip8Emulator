﻿namespace Chip8Emulator.Core.InstructionSet
{
    // 4xkk - SNE Vx, byte
    public class Op4xkk : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF000) == 0x4000;

        public override void Run(ushort opcode, Chip8System system)
        {
            var value = (ushort)(opcode & 0x00FF);
            var registerInedx = (ushort)((opcode & 0x0F00) >> 8);
            system.Cpu.PC += (ushort)(system.Cpu.V[registerInedx] != value ? 4 : 2);
        }
    }
}