using JME.Core;
using System.Diagnostics;

namespace JME
{
    public class Game
    {
        // Private Fields
        private bool _initialized = false;
        private bool _running = false;

        // FPS
        private double lastFpsUpdate = 0;
        private int frameCount = 0;
        private int fpsCount = 0;

        private readonly CoreContext _coreContext = new();

        // Public Properties
        public bool Initialized
        {
            get { return _initialized; }
            private set { _initialized = value; }
        }

        public bool Running
        {
            get { return _running; }
            private set { _running = value; }
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
            if (!Initialized)
            {
                Initialize();
            }

            // Set up Stopwatch for timing purposes
            Stopwatch sw = Stopwatch.StartNew();
            double latestTime;
            double deltaTime;

            latestTime = sw.Elapsed.TotalSeconds;
            lastFpsUpdate = latestTime;

            // We are ready to start running
            // Set Running to True
            Running = true;

            // Main Loop
            while (Running)
            {
                // Check how much time has passed
                double currentTime = sw.Elapsed.TotalSeconds;
                deltaTime = currentTime - latestTime;
                latestTime = currentTime;

                // Update Logic
                Update(deltaTime);

                //Render Logic
                Render();
                frameCount++;

                // Update FPS Count once per second
                if (latestTime - lastFpsUpdate >= 1.0)
                {
                    fpsCount = frameCount;
                    frameCount = 0;
                    lastFpsUpdate = latestTime;
                    Console.WriteLine($"FPS : {fpsCount}");
                }
            }

            Console.WriteLine("Game.Run() has been called");
        }

        public void Update(double deltaTime)
        {
            if(_coreContext.Initialized)
            {

            }
        }

        public void Render()
        {
            if (_coreContext.Initialized)
            {

            }
        }
    }
}
