namespace Chip8Emulator.Core.InstructionSet
{
    // 00E0 - CLS
    public class Op00E0 : Instruction
    {
        public override bool Match(ushort opcode) => opcode == 0x00E0;

        public override void Run(ushort opcode, Chip8System system)
        {
            system.GraphicMemory.Clear();
            system.Cpu.PC += 2;
        }
    }
}