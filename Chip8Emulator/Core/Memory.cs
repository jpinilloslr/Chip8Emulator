namespace Chip8Emulator.Core
{
    public class Memory
    {
        private readonly byte[] _data;

        public byte this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public Memory()
        {
            _data = new byte[4096];
        }
    }
}