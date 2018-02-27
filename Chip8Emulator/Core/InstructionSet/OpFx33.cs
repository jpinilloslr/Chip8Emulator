namespace Chip8Emulator.Core.InstructionSet
{
    // Fx33 - LD B, Vx
    public class OpFx33 : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xF033;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            system.Memory[system.Cpu.I] = (byte)(system.Cpu.V[registerIndex] / 100);
            system.Memory[system.Cpu.I + 1] = (byte)((system.Cpu.V[registerIndex] / 10) % 10);
            system.Memory[system.Cpu.I + 2] = (byte)((system.Cpu.V[registerIndex] % 100) % 10);
            system.Cpu.PC += 2;
        }
    }
}