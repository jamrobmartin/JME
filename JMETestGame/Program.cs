using JME;

namespace JMETestGame
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");

            Game game = new();

            game.Initialize();

            game.Run();
        }
    }
}
