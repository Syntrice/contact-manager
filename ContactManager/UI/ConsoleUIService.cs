using ContactManager.UI.States;
using Microsoft.Extensions.Hosting;

namespace ContactManager.UI
{
    public class ConsoleUIService : BackgroundService, IUIStateController
    {
        private IUIState _currentState;
        private IUIStateFactory _stateFactory;

        public ConsoleUIService(IUIStateFactory stateFactory)
        {
           _currentState = stateFactory.GetInstance<MainMenuState>();
           _stateFactory = stateFactory;
        }

        public Task SetState<State>() where State : IUIState
        {
            _currentState = _stateFactory.GetInstance<State>();
            return _currentState.ExecuteAsync(this, CancellationToken.None);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _currentState.ExecuteAsync(this, stoppingToken);
            return Task.CompletedTask;
        }
    }
}
