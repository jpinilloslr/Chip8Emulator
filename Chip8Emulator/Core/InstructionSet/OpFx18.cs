namespace Chip8Emulator.Core.InstructionSet
{
    // Fx18 - LD ST, Vx
    public class OpFx18 : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xF018;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            system.SoundTimer = system.Cpu.V[registerIndex];
            system.Cpu.PC += 2;
        }
    }
}