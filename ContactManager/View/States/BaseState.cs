using Spectre.Console;

namespace ContactManager.View.States
{
    public abstract class BaseState : IState
    {
        private Rule _title = new Rule(("Contact Manager")).LeftJustified();

        public virtual Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(_title);
            AnsiConsole.WriteLine();
            return Task.CompletedTask;
        }
    }
}
