namespace Chip8Emulator.Core.InstructionSet
{
    // Fx29 - LD F, Vx
    public class OpFx29 : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xF029;

        public override void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            system.Cpu.I = (ushort) (system.Cpu.V[registerIndex]  * 5);
            system.Cpu.PC += 2;
        }
    }
}