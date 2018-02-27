namespace Chip8Emulator.Core
{
    public class Stack
    {
        private ushort _sp;
        private readonly ushort[] _data;

        public Stack()
        {
            _data = new ushort[16];
        }

        public void Push(ushort address)
        {
            _data[_sp] = address;
            _sp++;
        }

        public ushort Pop()
        {
            var address = _data[_sp];
            _sp--;
            return address;
        }
    }
}