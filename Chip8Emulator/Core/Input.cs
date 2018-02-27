namespace Chip8Emulator.Core
{
    public class Input
    {
        private readonly bool[] _data;

        public bool this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public Input()
        {
            _data = new bool[16];
        }

        public byte? GetKeyPressed()
        {
            byte? key = null;
            for (byte i = 0; i < 16 && key == null; i++)
            {
                if (_data[i])
                {
                    key = i;
                }
            }
            return key;
        }
    }
}
