﻿namespace Chip8Emulator.Core
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
            _data = new byte[64 * 32];
        }

        public void Clear()
        {
            for (var i = 0; i < _data.Length; i++)
            {
                _data[i] = 0;
            }
        }
    }
}