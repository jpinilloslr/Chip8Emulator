namespace Chip8Emulator.Core.InstructionSet
{
    // Fx0A - LD Vx, K
    public class Fx0A : IInstruction
    {
        public bool Match(ushort opcode) => (opcode & 0xF0FF) == 0xF00A;

        public void Run(ushort opcode, Chip8System system)
        {
            var registerIndex = (byte)((opcode & 0x0F00) >> 8);
            var key = system.Input.GetKeyPressed();
            if (key != null)
            {
                system.Cpu.V[registerIndex] = key.Value;
                system.Cpu.PC += 2;
            }            
        }
    }
}