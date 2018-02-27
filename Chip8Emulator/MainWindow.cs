using System;
using System.Windows.Forms;
using Chip8Emulator.Core;
using Chip8Emulator.Core.HardwareInterfaces;

namespace Chip8Emulator
{
    public partial class MainWindow : Form, IScreen, IKeyboard, IBuzzer
    {
        private readonly Chip8System _system;

        public MainWindow()
        {
            InitializeComponent();
            _system = new Chip8System(this, this, this);
            _system.Initialize();
            _system.LoadRom(@"Games\PONG");            
        }

        public void Refresh(GraphicMemory graphicMemory)
        {
            
        }

        public void BindKeyboardEvents(Input input)
        {
            
        }

        public void Beep()
        {
            Console.Beep();
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            _system.Step();
        }
    }
}