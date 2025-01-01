namespace ContactManager.View.States
{
    public interface IState
    {
        public Task Execute(IStateController controller, CancellationToken stoppingToken);
    }
}
