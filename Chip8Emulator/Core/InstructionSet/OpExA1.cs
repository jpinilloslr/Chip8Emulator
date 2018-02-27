namespace Chip8Emulator.Core.InstructionSet
{
    // ExA1 - SKNP Vx
    public class ExA1 : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xE0A1;

        public override void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            var keyValue = system.Cpu.V[registerIndex];
            system.Cpu.PC += (ushort)(!system.Input[keyValue] ? 4 : 2);
        }
    }
}