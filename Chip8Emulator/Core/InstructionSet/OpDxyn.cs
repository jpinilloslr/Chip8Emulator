namespace Chip8Emulator.Core.InstructionSet
{
    // Dxyn - DRW Vx, Vy, nibble
    public class OpDxyn : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF000) == 0xD000;

        public override void Run(ushort opcode, Chip8System system)
        {
            // TODO: Draw
            system.Cpu.PC += 2;
        }
    }
}