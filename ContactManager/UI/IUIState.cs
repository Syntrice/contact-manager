namespace ContactManager.UI
{
    public interface IUIState
    {
        public Task ExecuteAsync(IUIStateController controller, CancellationToken stoppingToken);
    }
}
