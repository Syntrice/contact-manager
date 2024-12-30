namespace ContactManager.UI
{
    public class UIStateFactory : IUIStateFactory
    {
        private readonly IEnumerable<IUIState> _uiStates;

        public UIStateFactory(IEnumerable<IUIState> uiStates)
        {
            _uiStates = uiStates;
        }

        public IUIState GetInstance<State>() where State : IUIState
        {
            IUIState? instance = _uiStates.OfType<State>().FirstOrDefault();
            if (instance == null)
            {
                throw new InvalidOperationException($"No IUIState dependency of type {typeof(State).Name} found.");
            }
            else
            {
                return instance;
            }
        }
    }
}
