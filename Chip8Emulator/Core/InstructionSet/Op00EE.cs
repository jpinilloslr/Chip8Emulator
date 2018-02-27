namespace Chip8Emulator.Core.InstructionSet
{
    // 00EE - RET
    public class Op00EE : Instruction
    {
        public override bool Match(ushort opcode) => opcode == 0x00EE;

        public override void Run(ushort opcode, Chip8System system)
        {
            var address = system.Stack.Pop();
            system.Cpu.PC = address;
        }
    }
}