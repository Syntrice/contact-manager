using ContactManager.Logic;
using Spectre.Console;

namespace ContactManager.View.States
{
    public class BrowseContactsState : BaseState, IState
    {
        private readonly IContactsLogic _logic;
        public BrowseContactsState(IContactsLogic contactsLogic)
        {
            _logic = contactsLogic;
        }

        public override async Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            Clear();
            var request = await _logic.GetContactsAsync();
            switch (request.Type)
            {
                case ResponseType.Success:
                    AnsiConsole.WriteLine(string.Join("\n",request.Value.Select(c => c.Name)));
                    break;
                case ResponseType.Failiure:
                    AnsiConsole.MarkupLine($"[red]{request.Message}[/]");
                    break;
            }

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("Press any key to continue...");
            await Task.Run(() => Console.ReadKey());

            controller.SetState(typeof(MainMenuState));
        }
    }
}
