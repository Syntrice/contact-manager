using ContactManager.Logic;
using Spectre.Console;

namespace ContactManager.View.States
{
    public class TestState : BaseState, IState
    {
        private readonly IContactsLogic _logic;

        private SelectionPrompt<string> _menuPrompt = new SelectionPrompt<string>()
            .Title("Please select an option")
            .AddChoices(new[] { "Back", "List all email categories", "List all phone number categories" });

        public TestState(IContactsLogic logic)
        {
            _logic = logic;
        }

        public override async Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            await base.Execute(controller, stoppingToken);
            string choice = await Task.Run(() => AnsiConsole.Prompt<string>(_menuPrompt));

            switch (choice)
            {
                case "Back":
                    controller.SetState(typeof(MainMenuState));
                    break;
                case "List all email categories":
                    var numbers = await _logic.GetPhoneNumberCategoryLabelsAsync();
                    AnsiConsole.WriteLine(string.Join("\n", numbers));
                    AnsiConsole.WriteLine("Press any key to continue...");
                    await Task.Run(() => Console.ReadKey());
                    break;
                case "List all phone number categories":
                    var emails = await _logic.GetEmailAddressCategoryLabelsAsync();
                    AnsiConsole.WriteLine(string.Join("\n", emails));
                    AnsiConsole.WriteLine("Press any key to continue...");
                    await Task.Run(() => Console.ReadKey());
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
