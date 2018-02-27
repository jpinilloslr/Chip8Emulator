namespace Chip8Emulator.Core.InstructionSet
{
    // Fx65 - LD Vx, [I]
    public class OpFx65 : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xF065;

        public override void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            for (var i = 0; i <= registerIndex; i++)
            {
                system.Cpu.V[i] = system.Memory[system.Cpu.I + i];
            }
            system.Cpu.I += registerIndex;
            system.Cpu.I++;
            system.Cpu.PC += 2;
        }
    }
}