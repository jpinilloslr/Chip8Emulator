namespace Chip8Emulator.Core.InstructionSet
{
    // 7xkk - ADD Vx, byte
    public class Op7xkk : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF000) == 0x7000;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerInedx = (ushort)((opcode & 0x0F00) >> 8);
            var value = (byte)(opcode & 0x00FF);
            system.Cpu.V[registerInedx] += value;
            system.Cpu.PC += 2;
        }
    }
}