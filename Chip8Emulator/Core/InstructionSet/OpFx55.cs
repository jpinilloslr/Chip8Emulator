namespace Chip8Emulator.Core.InstructionSet
{
    // Fx55 - LD [I], Vx
    public class OpFx55 : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xF055;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            for (var i = 0; i < registerIndex; i++)
            {
                system.Memory[system.Cpu.I + i] = system.Cpu.V[i];
            }
            system.Cpu.PC += 2;
        }
    }
}