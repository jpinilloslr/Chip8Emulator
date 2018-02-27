namespace Chip8Emulator.Core.InstructionSet
{
    // 8xy6 - SHR Vx {, Vy}
    public class Op8xy6 : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF00F) == 0x8006;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            system.Cpu.V[0xF] = (byte)(system.Cpu.V[registerIndex] & 1);
            system.Cpu.V[registerIndex] >>= 1;
            system.Cpu.PC += 2;
        }
    }
}