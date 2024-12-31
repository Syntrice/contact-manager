using ContactManager.Services.UI;

namespace ContactManager.Services.UI.States
{
    public interface IUIState
    {
        public Task Execute(IUIStateController controller, CancellationToken stoppingToken);
    }
}
