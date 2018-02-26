namespace Chip8Emulator.Core
{
    public class Cpu
    {
        public byte[] V { get; set; }
        public ushort I { get; set; }
        public ushort PC { get; set; }

        public Cpu()
        {
            V = new byte[16];
        }
    }
}
