namespace Chip8Emulator.Core.InstructionSet
{
    // 9xy0 - SNE Vx, Vy
    public class Op9xy0 : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF00F) == 0x9000;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerIndex1 = (byte)((opcode & 0x0F00) >> 8);
            var registerIndex2 = (byte)((opcode & 0x00F0) >> 4);
            system.Cpu.PC += (byte)(system.Cpu.V[registerIndex1] != system.Cpu.V[registerIndex2] ? 4 : 2);
        }
    }
}