using ContactManager.Options;
using ContactManager.View.States;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContactManager.View
{
    public class ConsoleUIService : BackgroundService, IUIStateController
    {
        private readonly IEnumerable<IUIState> _uiStates;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly ILogger _logger;
        private readonly ConsoleUIOptions _options;
        private IUIState _currentState = null!;

        public ConsoleUIService(
            IEnumerable<IUIState> uiStates,
            IHostApplicationLifetime appLifetime,
            ILogger<ConsoleUIService> logger,
            IOptions<ConsoleUIOptions> options)
        {
            _uiStates = uiStates;
            _appLifetime = appLifetime;
            _logger = logger;
            _options = options.Value;
        }

        public void SetState(Type type)
        {
            IUIState? instance = _uiStates.FirstOrDefault(x => x.GetType() == type);
            if (instance == null)
            {
                throw new InvalidOperationException($"No IUIState dependency of type {type.Name} found.");
            }
            else
            {
                _logger.LogInformation($"Setting UI state to {type.Name}");
                _currentState = instance;
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"ExecuteAsync has been called");
            SetState(_options.StartingUIState);
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
