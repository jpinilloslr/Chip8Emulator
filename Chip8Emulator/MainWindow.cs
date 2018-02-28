using System;
using System.Collections.Generic;
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
        private Input _input;

        public MainWindow()
        {
            InitializeComponent();
            _system = new Chip8System(this, this, this);
            _system.Initialize();
            _system.LoadRom(@"Games\TETRIS");
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
            _input = input;
        }

        public void Beep()
        {
            Console.Beep();
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            _system.Step();
        }

        private readonly Dictionary<Keys, byte> _mapping = new Dictionary<Keys, byte>
        {
            {Keys.D1, 0x1},
            {Keys.D2, 0x2},
            {Keys.D3, 0x3},
            {Keys.D4, 0xC},
            {Keys.Q, 0x4},
            {Keys.W, 0x5},
            {Keys.E, 0x6},
            {Keys.R, 0xD},
            {Keys.A, 0x7},
            {Keys.S, 0x8},
            {Keys.D, 0x9},
            {Keys.F, 0xE},
            {Keys.Z, 0xA},
            {Keys.X, 0x0},
            {Keys.C, 0xB},
            {Keys.V, 0xF},
        };

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (_input == null || !_mapping.ContainsKey(e.KeyCode))
            {
                return;
            }

            var index = _mapping[e.KeyCode];
            _input[index] = true;
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (_input == null || !_mapping.ContainsKey(e.KeyCode))
            {
                return;
            }

            var index = _mapping[e.KeyCode];
            _input[index] = false;
        }
    }
}