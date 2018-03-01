using System;

namespace Chip8Emulator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MainWindow())
            {
                game.Run(60);
            }
        }
    }
}