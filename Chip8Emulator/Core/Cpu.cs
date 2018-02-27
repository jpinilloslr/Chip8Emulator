using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chip8Emulator.Core.InstructionSet;

namespace Chip8Emulator.Core
{
    public class Cpu
    {
        private readonly Chip8System _system;
        private IEnumerable<IInstruction> _instructionSet;

        public byte[] V { get; set; }
        public ushort I { get; set; }
        public ushort PC { get; set; }

        public Cpu(Chip8System system)
        {
            _system = system;
            V = new byte[16];
            PC = 0x200;
            LoadInstructionSet();
        }

        private void LoadInstructionSet()
        {
            _instructionSet = Assembly.GetCallingAssembly().GetTypes()
                .Where(x => x.GetInterface(nameof(IInstruction)) != null)
                .Select(x => (IInstruction)Activator.CreateInstance(x));
        }

        public void Step()
        {
            var opcode = FetchOpcode();
            var instruction = _instructionSet.FirstOrDefault(x => x.Match(opcode));
            if (instruction == null)
            {
                throw new Exception("Unknown opcode");
            }
            instruction.Run(opcode, _system);
        }

        private ushort FetchOpcode()
        {
            return (ushort) ((_system.Memory[PC] << 8) | _system.Memory[PC + 1]);
        }
    }
}