using ContactManager.View;

namespace ContactManager.View.States
{
    public class TestState : IState
    {
        public Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            Console.WriteLine();
            Console.WriteLine("Testing menu");
            Console.WriteLine();
            controller.SetState(typeof(MainMenuState));
            return Task.CompletedTask;
        }
    }
}
