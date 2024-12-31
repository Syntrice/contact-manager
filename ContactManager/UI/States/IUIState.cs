namespace ContactManager.UI.States
{
    public interface IUIState
    {
        public Task Execute(IUIStateController controller, CancellationToken stoppingToken);
    }
}
