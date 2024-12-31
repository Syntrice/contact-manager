using ContactManager.UI.States;
using Microsoft.Extensions.Hosting;

namespace ContactManager.UI
{
    public class ConsoleUIService : BackgroundService, IUIStateController
    {
        private readonly IEnumerable<IUIState> _uiStates;
        private bool _isRunning;
        private IUIState _currentState = null!;

        public ConsoleUIService(IEnumerable<IUIState> uiStates)
        {
            _uiStates = uiStates;
            SetState<MainMenuState>();
        }

        public void SetState<State>() where State : IUIState
        {
            IUIState? instance = _uiStates.OfType<State>().FirstOrDefault();
            if (instance == null)
            {
                throw new InvalidOperationException($"No IUIState dependency of type {typeof(State).Name} found.");
            }
            else
            {
                _currentState = instance;
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _isRunning = true;
            while (_isRunning)
            {
                _currentState.Execute(this, stoppingToken);
            }
            return Task.CompletedTask;
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
