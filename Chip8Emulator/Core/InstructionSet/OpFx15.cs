namespace Chip8Emulator.Core.InstructionSet
{
    // Fx15 - LD DT, Vx
    public class OpFx15 : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xF015;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            system.DelayTimer = system.Cpu.V[registerIndex];
            system.Cpu.PC += 2;
        }
    }
}