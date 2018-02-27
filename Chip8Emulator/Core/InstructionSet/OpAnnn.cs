namespace Chip8Emulator.Core.InstructionSet
{
    // Annn - LD I, addr
    public class OpAnnn : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF000) == 0xA000;

        public override void Run(ushort opcode, Chip8System system)
        {
            var address = (ushort)(opcode & 0x0FFF);
            system.Cpu.I = address;
            system.Cpu.PC += 2;
        }
    }
}