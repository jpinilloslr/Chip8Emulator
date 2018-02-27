namespace Chip8Emulator.Core.InstructionSet
{
    // 00EE - RET
    public class ReturnInstruction : IInstruction
    {
        public bool Match(ushort opcode) => opcode == 0x00EE;

        public void Run(ushort opcode, Chip8System system)
        {
            var address = system.Stack.Pop();
            system.Cpu.PC = address;
        }
    }
}