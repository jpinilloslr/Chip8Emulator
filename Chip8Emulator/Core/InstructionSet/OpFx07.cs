namespace Chip8Emulator.Core.InstructionSet
{
    // Fx07 - LD Vx, DT
    public class Fx07 : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xF007;

        public override void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            system.Cpu.V[registerIndex] = system.DelayTimer;
            system.Cpu.PC += 2;
        }
    }
}