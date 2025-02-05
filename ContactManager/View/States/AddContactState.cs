using ContactManager.Services;
using ContactManager.Wrappers;
using Spectre.Console;
using SQLitePCL;

namespace ContactManager.View.States
{
    public class AddContactState : BaseState, IState
    {
        private readonly IContactService _logic;

        public AddContactState(IContactService logic)
        {
            _logic = logic;
        }

        public override async Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            Clear();

            string name = await Task.Run(() =>
            {
                return AnsiConsole.Prompt<string>(new TextPrompt<string>("Enter Contact Name:"));
            });

            var request = await _logic.CreateContactAsync(name);

            switch (request.Type)
            {
                case ServiceResponseType.Success:
                    Console.WriteLine($"Successfuly added contact '{name}'");
                    break;
                case ServiceResponseType.Failure:
                    AnsiConsole.MarkupLine($"[red]{request.Message}[/]");
                    break;
            }


            AnsiConsole.WriteLine("Press any key to continue...");
            await Task.Run(() => Console.ReadKey());
            controller.SetState(typeof(MainMenuState));
        }
    }
}
