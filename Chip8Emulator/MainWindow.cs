using System.Windows.Forms;
using Chip8Emulator.Core;

namespace Chip8Emulator
{
    public partial class MainWindow : Form
    {
        private Chip8System _system;

        public MainWindow()
        {
            InitializeComponent();
            _system = new Chip8System();
            _system.Initialize();
            _system.LoadRom(@"Games\PONG");
            
            for (;;)
            {
                _system.Step();
            }
        }
    }
}