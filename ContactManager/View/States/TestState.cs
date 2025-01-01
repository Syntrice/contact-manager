using Spectre.Console;

namespace ContactManager.View.States
{
    public class TestState : BaseState, IState
    {
        public override async Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            await base.Execute(controller, stoppingToken);
            AnsiConsole.WriteLine("Testing State");
            await Task.Delay(2000);
            controller.SetState(typeof(MainMenuState));
        }
    }
}
