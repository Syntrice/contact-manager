using ContactManager.View.States;

namespace ContactManager.ApplicationOptions
{
    public class ConsoleUIOptions : IConsoleUIOptions
    {
        private Type _startingState = null!;
        public Type StartingState
        {
            get
            {
                return _startingState;
            }

            set
            {
                if (!typeof(IState).IsAssignableFrom(value))
                {
                    throw new ArgumentException("The starting UI state must implement IUIState");
                }
                else
                {
                    _startingState = value;
                }
            }
        }
    }
}
