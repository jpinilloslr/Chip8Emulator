namespace Chip8Emulator.Core.InstructionSet
{
    public abstract class Instruction
    {
        public abstract bool Match(ushort opcode);
        public abstract void Run(ushort opcode, Chip8System system);
        public virtual bool ShouldContinueExecution() => true;
    }
}