
namespace JME.Core
{
    public class CoreContext
    {
        // Private Fields
        private bool _initialized = false;

        // Private Managers

        // Public Properties
        public bool Initialized
        {
            get { return _initialized; }
            private set { _initialized = value; }
        }

        public CoreContext() { }

        public void Initialize()
        {
            Console.WriteLine("CoreContext Initialized");
            _initialized = true;
        }
    }
}
