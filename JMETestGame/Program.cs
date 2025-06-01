using JME;
using JME.Core;

namespace JMETestGame
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");

            Game game = new();

            WindowSettings windowSettings = new()
            {
                Width = 800,
                Height = 600,
            };

            game.Initialize(windowSettings);

            game.Run();
        }
    }
}
