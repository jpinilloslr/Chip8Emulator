using System;

namespace Chip8Emulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new MainWindow())
            {
                game.Run(60); // 60 Hz
            }
        }
    }
}
