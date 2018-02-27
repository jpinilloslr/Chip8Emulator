namespace Chip8Emulator.Core.InstructionSet
{
    // 0nnn - SYS addr
    public class Op0nnn : IInstruction
    {
        public bool Match(ushort opcode) => 
            (opcode & 0xF000) == 0x0000 && opcode != 0x00EE && opcode != 0x00E0;

        public void Run(ushort opcode, Chip8System system)
        {
            // Obsolete instruction, ignore
            system.Cpu.PC += 2;
        }
    }
}