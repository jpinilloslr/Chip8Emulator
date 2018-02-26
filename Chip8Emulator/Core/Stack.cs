namespace Chip8Emulator.Core
{
    public class Stack
    {
        private short _sp;
        private readonly short[] _data;

        public Stack()
        {
            _data = new short[16];
        }

        public void Push(short address)
        {
            _data[_sp] = address;
            _sp++;
        }

        public short Pop()
        {
            var address = _data[_sp];
            _sp--;
            return address;
        }
    }
}