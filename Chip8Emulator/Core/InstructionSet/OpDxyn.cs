using System.Net.Security;

namespace Chip8Emulator.Core.InstructionSet
{
    // Dxyn - DRW Vx, Vy, nibble
    public class OpDxyn : Instruction
    {
        public override bool Match(ushort opcode) => (opcode & 0xF000) == 0xD000;

        public override void Run(ushort opcode, Chip8System system)
        {
            var xRegisterIndex = (byte)((opcode & 0x0F00) >> 8);
            var yRegisterIndex = (byte)((opcode & 0x00F0) >> 4);
            var height = (byte)(opcode & 0x000F);
            var x = system.Cpu.V[xRegisterIndex];
            var y = system.Cpu.V[yRegisterIndex];

            system.Cpu.V[0xF] = 0;
            for (var yLine = 0; yLine < height; yLine++)
            {
                var pixel = system.Memory[system.Cpu.I + yLine];
                for (var xLine = 0; xLine < 8; xLine++)
                {
                    if ((pixel & (0x80 >> xLine)) == 0)
                        continue; 

                    var index = x + xLine + (y + yLine) * 64;
                    if (index > system.GraphicMemory.Size - 1)
                        continue;

                    if (system.GraphicMemory[index] == 1) 
                    {
                        system.Cpu.V[0xF] = 1; 
                    }

                    system.GraphicMemory[index] ^= 1;
                }
            }

            system.Cpu.PC += 2;
            system.InvalidateScreen();
        }
    }
}