using ContactManager.Services.UI;

namespace ContactManager.Services.UI.States
{
    public class TestState : IUIState
    {
        public Task Execute(IUIStateController controller, CancellationToken stoppingToken)
        {
            Console.WriteLine();
            Console.WriteLine("Testing menu");
            Console.WriteLine();
            controller.SetState<MainMenuState>();
            return Task.CompletedTask;
        }
    }
}
