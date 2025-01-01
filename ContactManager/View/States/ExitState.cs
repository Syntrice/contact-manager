using ContactManager.View;

namespace ContactManager.View.States
{
    public class ExitState : IState
    {
        public Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            Console.WriteLine("Exiting...");
            controller.Stop();
            stoppingToken.WaitHandle.WaitOne();
            return Task.CompletedTask;
        }
    }
}
