namespace Chip8Emulator.Core.InstructionSet
{
    // 2nnn - CALL addr
    public class Op2nnn : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF000) == 0x2000;

        public void Run(ushort opcode, Chip8System system)
        {
            var address = (ushort)(opcode & 0x0FFF);
            system.Cpu.PC += 2;
            system.Stack.Push(system.Cpu.PC);
            system.Cpu.PC = address;
        }
    }
}