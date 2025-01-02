using Spectre.Console;

namespace ContactManager.View.States
{
    public class MainMenuState : BaseState, IState
    {
        private SelectionPrompt<string> _menuPrompt = new SelectionPrompt<string>()
            .Title("Main Menu")
            .AddChoices(new[] { "Exit" });

        public override async Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            await base.Execute(controller, stoppingToken);
            string choice = await Task.Run(() => AnsiConsole.Prompt<string>(_menuPrompt));

            switch (choice)
            {
                case "Exit":
                    controller.SetState(typeof(ExitState));
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        
    }
}
