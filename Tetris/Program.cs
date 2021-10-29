using static System.Console;

namespace Tetris
{
    internal static class Program
    {
        private static void Main()
        {
            Title = "Tetris: Made by Juan Ibargoitia";
            CursorVisible = false;
            
            /*WindowWidth = 21 * 2;
            BufferWidth = 21 * 2;
            WindowHeight = 20;
            BufferHeight = 20;*/
            
            var game = new Game();
        }
    }
}