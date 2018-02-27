using System.Linq;

namespace Chip8Emulator.Core
{
    public class GraphicMemory
    {
        private readonly byte[] _data;

        public byte this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public GraphicMemory()
        {
            Size = 64 * 32;
            _data = new byte[Size];
        }

        public void Clear()
        {
            for (var i = 0; i < Size; i++)
            {
                _data[i] = 0;
            }
        }

        public int Size { get; }

        public override string ToString() => 
            string.Join(", ", _data.Select(x => x.ToString()));
    }
}