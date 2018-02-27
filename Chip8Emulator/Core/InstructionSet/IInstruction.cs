namespace Chip8Emulator.Core.InstructionSet
{
    public interface IInstruction
    {
        bool Match(ushort opcode);
        void Run(ushort opcode, Chip8System system);
    }
}