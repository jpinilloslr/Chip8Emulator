using System;
using System.Drawing;
using System.Windows.Forms;
using Chip8Emulator.Core;
using Chip8Emulator.Core.HardwareInterfaces;

namespace Chip8Emulator
{
    public partial class MainWindow : Form, IScreen, IKeyboard, IBuzzer
    {
        private readonly Chip8System _system;
        private readonly Graphics _graphics;

        public MainWindow()
        {
            InitializeComponent();
            _system = new Chip8System(this, this, this);
            _system.Initialize();
            _system.LoadRom(@"Games\BLINKY");
            _graphics = pictureBox.CreateGraphics();
            _graphics.Clear(Color.Black);
        }

        public void Refresh(GraphicMemory graphicMemory)
        {
            const int pixelSize = 10;            
            _graphics.Clear(Color.Black);
            for (var x = 0; x < 64; x++)
            {
                for (var y = 0; y < 32; y++)
                {
                    var pixel = graphicMemory[x+y*64];
                    if (pixel == 1)
                    {
                        _graphics.FillRectangle(Brushes.White,
                            new Rectangle(x * pixelSize, y * pixelSize, pixelSize, pixelSize));
                    }
                }
            }
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