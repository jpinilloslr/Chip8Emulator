namespace Chip8Emulator.Core.InstructionSet
{
    // Fx1E - ADD I, Vx
    public class OpFx1E : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xF01E;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            system.Cpu.I += system.Cpu.V[registerIndex];
            system.Cpu.PC += 2;
        }
    }
}