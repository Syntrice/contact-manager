namespace ContactManager.UI.States
{
    public class MainMenuState : IUIState
    {
        public Task ExecuteAsync(IUIStateController controller, CancellationToken stoppingToken)
        {
            Console.WriteLine("--- Contact Manager ---");
            while (true)
            {
                Console.WriteLine("Please enter a command. Possible Commands: 0 - Exit, 1 - Test");
                var command = Console.ReadLine();
                if (command == "0")
                {
                    return Task.CompletedTask;
                }
                else if (command == "1")
                {
                    return controller.SetState<TestState>();
                }
                else
                {
                    Console.WriteLine("Invalid command. Please try again.");
                }
            }
        }
    }
}
