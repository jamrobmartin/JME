using JME;
using JME.Core;
using JMETestGame.TestScenes;

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

            BasicScene scene = new();

            game.SetActiveScene(scene);

            game.Run();
        }
    }
}
