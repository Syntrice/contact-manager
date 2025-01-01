using ContactManager.View.States;

namespace ContactManager.Options
{
    public class ConsoleUIOptions
    {
        private Type _startingUIState = null!;
        public Type StartingUIState
        {
            get
            {
                return _startingUIState;
            }

            set
            {
                if (!typeof(IUIState).IsAssignableFrom(value))
                {
                    throw new ArgumentException("The starting UI state must implement IUIState");
                }
                else
                {
                    _startingUIState = value;
                }
            }
        }
    }
}
