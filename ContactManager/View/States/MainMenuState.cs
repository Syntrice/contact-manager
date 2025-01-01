using ContactManager.View;

namespace ContactManager.View.States
{
    public class MainMenuState : IState
    {
        public async Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            Console.WriteLine("--- Contact Manager ---");
            while (true)
            {
                Console.WriteLine("Please enter a command. Possible Commands: 0 - Exit, 1 - Test");
                var command = await Task.Run(() => Console.ReadLine());

                if (command == "0")
                {
                    controller.SetState(typeof(ExitState));
                    return;
                }
                else if (command == "1")
                {
                    controller.SetState(typeof(TestState));
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid command. Please try again.");
                }
            }
        }
    }
}
