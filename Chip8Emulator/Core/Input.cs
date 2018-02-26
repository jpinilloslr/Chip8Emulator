namespace Chip8Emulator.Core
{
    public class Input
    {
        private readonly byte[] _data;

        public byte this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public Input()
        {
            _data = new byte[16];
        }
    }
}
