using ContactManager.Options;
using ContactManager.View.States;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContactManager.View
{
    public class ConsoleUIService : BackgroundService, IStateController
    {
        private readonly IEnumerable<IState> _uiStates;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly ILogger _logger;
        private readonly ConsoleUIOptions _options;
        public IState CurrentState {  get; private set; } = null!;

        public ConsoleUIService(
            IEnumerable<IState> uiStates,
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
            IState? instance = _uiStates.FirstOrDefault(x => x.GetType() == type);
            if (instance == null)
            {
                throw new InvalidOperationException($"No IUIState dependency of type {type.Name} found.");
            }
            else
            {
                _logger.LogInformation($"Setting UI state to {type.Name}");
                CurrentState = instance;
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"ExecuteAsync has been called");
            SetState(_options.StartingState);
            while (!stoppingToken.IsCancellationRequested)
            {
                await CurrentState.Execute(this, stoppingToken);
            }
        }

        public void Stop()
        {
            _logger.LogInformation($"Requesting application stop");
            _appLifetime.StopApplication();
        }
    }
}
