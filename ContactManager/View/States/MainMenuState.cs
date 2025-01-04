using Spectre.Console;

namespace ContactManager.View.States
{
    using ChoiceAction = (Action<IStateController> Action, string Name);
    public class MainMenuState : BaseState, IState
    {

        private static List<ChoiceAction> _choices = new List<ChoiceAction>
        {
            ( (controller) => controller.SetState(typeof(ExitState)), "Exit" ),
            ( (controller) => controller.SetState(typeof(AddContactState)), "Add Contact" ),
            ( (controller) => controller.SetState(typeof(BrowseContactsState)), "List Contacts" )
        };

        private static SelectionPrompt<ChoiceAction> _menu = new SelectionPrompt<ChoiceAction>()
            .Title("Main Menu")
            .AddChoices(_choices)
            .UseConverter(choice => choice.Name);

        public override async Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            Clear();
            var choice = await Task.Run(() => AnsiConsole.Prompt<ChoiceAction>(_menu));
            choice.Action.Invoke(controller);
        }
    }
}
