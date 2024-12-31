using ContactManager.UI.States;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContactManager.UI
{
    public class ConsoleUIService : BackgroundService, IUIStateController
    {
        private readonly IEnumerable<IUIState> _uiStates;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly ILogger _logger;
        private IUIState _currentState = null!;

        public ConsoleUIService(IEnumerable<IUIState> uiStates, IHostApplicationLifetime appLifetime, ILogger<ConsoleUIService> logger)
        {
            _uiStates = uiStates;
            _appLifetime = appLifetime;
            _logger = logger;
        }

        public void SetState<State>() where State : IUIState
        {
            _logger.LogInformation($"Setting UI state to {typeof(State).Name}");
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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"ExecuteAsync has been called");
            SetState<MainMenuState>();
            while (!stoppingToken.IsCancellationRequested)
            {
                await _currentState.Execute(this, stoppingToken);
            }
        }

        public void Stop()
        {
            _logger.LogInformation($"Requesting application stop");
            _appLifetime.StopApplication();
        }
    }
}
