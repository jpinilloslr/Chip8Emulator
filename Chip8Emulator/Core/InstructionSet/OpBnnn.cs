namespace Chip8Emulator.Core.InstructionSet
{
    // Bnnn - JP V0, addr
    public class OpBnnn : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF000) == 0xB000;

        public override void Run(ushort opcode, Chip8System system)
        {
            var address = (ushort)(opcode & 0x0FFF);
            system.Cpu.PC += (ushort)(address + system.Cpu.V[0]);
        }
    }
}