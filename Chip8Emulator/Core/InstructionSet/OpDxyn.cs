namespace Chip8Emulator.Core.InstructionSet
{
    // Dxyn - DRW Vx, Vy, nibble
    public class OpDxyn : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF000) == 0xD000;

        public void Run(ushort opcode, Chip8System system)
        {
            // TODO: Draw
            system.Cpu.PC += 2;
        }
    }
}