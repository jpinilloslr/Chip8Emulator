namespace Chip8Emulator.Core.InstructionSet
{
    // 5xy0 - SE Vx, Vy
    public class Op5xy0 : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF000) == 0x5000;

        public override void Run(ushort opcode, Chip8System system)
        {
            var registerInedx1 = (ushort)((opcode & 0x0F00) >> 8);
            var registerInedx2 = (ushort)((opcode & 0x00F0) >> 4);
            system.Cpu.PC += (ushort)(system.Cpu.V[registerInedx1] == system.Cpu.V[registerInedx2] ? 4 : 2);
        }
    }
}