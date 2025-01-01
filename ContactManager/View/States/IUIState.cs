using ContactManager.View;

namespace ContactManager.View.States
{
    public interface IUIState
    {
        public Task Execute(IUIStateController controller, CancellationToken stoppingToken);
    }
}
