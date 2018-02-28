namespace Chip8Emulator.Core.InstructionSet
{
    // 8xy1 - OR Vx, Vy
    public class Op8xy1 : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF00F) == 0x8001;

        public override void Run(ushort opcode, Chip8System system)
        {
            var registerIndex1 = (byte)((opcode & 0x0F00) >> 8);
            var registerIndex2 = (byte)((opcode & 0x00F0) >> 4);
            system.Cpu.V[registerIndex1] |= system.Cpu.V[registerIndex2];
            system.Cpu.V[0xF] = 0;
            system.Cpu.PC += 2;
        }
    }
}