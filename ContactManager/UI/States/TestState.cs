namespace ContactManager.UI.States
{
    public class TestState : IUIState
    {
        public Task ExecuteAsync(IUIStateController controller, CancellationToken stoppingToken)
        {
            Console.WriteLine();
            Console.WriteLine("Testing menu");
            Console.WriteLine();
            return controller.SetState<MainMenuState>();
        }
    }
}
