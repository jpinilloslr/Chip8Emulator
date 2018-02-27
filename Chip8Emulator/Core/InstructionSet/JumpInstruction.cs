namespace Chip8Emulator.Core.InstructionSet
{
    // 1nnn - JP addr
    public class JumpInstruction : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF000) == 0x1000;

        public void Run(ushort opcode, Chip8System system)
        {
            var address = (ushort)(opcode & 0x0FFF);
            system.Cpu.PC = address;
        }
    }
}