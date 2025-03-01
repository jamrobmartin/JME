using JME.Core;

namespace JME
{
    public class Game
    {
        // Private Fields
        private bool _initialized = false;

        private readonly CoreContext _coreContext = new();

        // Public Properties
        public bool Initialized
        {
            get { return _initialized; }
            private set { _initialized = value; }
        }

        public Game()
        {
            
        }

        public void Initialize()
        {
            _coreContext.Initialize();

            Initialized = true;

            Console.WriteLine("Game.Initialize() has been called");
        }

        public void Run()
        {
            // If the Game wasn't manually initialized,
            // Initialize it now.
            if(!Initialized)
            {
                Initialize();
            }

            Console.WriteLine("Game.Run() has been called");
        }
    }
}
