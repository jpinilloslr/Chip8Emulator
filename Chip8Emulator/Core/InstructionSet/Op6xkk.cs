namespace Chip8Emulator.Core.InstructionSet
{
    // 6xkk - LD Vx, byte
    public class Op6xkk : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF000) == 0x6000;

        public void Run(ushort opcode, Chip8System system)
        {
            var value = (byte)(opcode & 0x00FF);
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            system.Cpu.V[registerIndex] = value;
            system.Cpu.PC += 2;
        }
    }
}