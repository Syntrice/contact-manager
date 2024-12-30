using Microsoft.Extensions.Hosting;

namespace ContactManager.Services
{
    public class ConsoleUIService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("--- Contact Manager ---");
            while (true)
            {

                Console.WriteLine("Enter a command:");
                Console.WriteLine("Possible comamnds: 0 - Exit");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        return Task.CompletedTask;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
