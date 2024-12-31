namespace ContactManager.UI.States
{
    public class MainMenuState : IUIState
    {
        public async Task Execute(IUIStateController controller, CancellationToken stoppingToken)
        {
            Console.WriteLine("--- Contact Manager ---");
            while (true)
            {
                Console.WriteLine("Please enter a command. Possible Commands: 0 - Exit, 1 - Test");
                var command = await Task.Run(() => Console.ReadLine());

                if (command == "0")
                {
                    controller.SetState<ExitState>();
                    return;
                }
                else if (command == "1")
                {
                    controller.SetState<TestState>();
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
