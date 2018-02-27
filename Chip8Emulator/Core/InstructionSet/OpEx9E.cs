namespace Chip8Emulator.Core.InstructionSet
{
    // Ex9E - SKP Vx
    public class Ex9E : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xE09E;

        public override void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            var keyValue = system.Cpu.V[registerIndex];
            system.Cpu.PC += (ushort)(system.Input[keyValue] ? 4 : 2);
        }
    }
}