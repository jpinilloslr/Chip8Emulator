namespace Chip8Emulator.Core
{
    public class System
    {
        private short _delayTimer;
        private short _soundTimer;

        private readonly Cpu _cpu;
        private readonly Stack _stack;
        private readonly Input _input;
        private readonly Memory _memory;
        private readonly GraphicMemory _graphicMemory;        

        public System()
        {
            _cpu = new Cpu();
            _stack = new Stack();
            _input = new Input();
            _memory = new Memory();
            _graphicMemory = new GraphicMemory();
        }

        public void Initialize()
        {
            
        }

        public void Run()
        {
            
        }
    }
}