﻿using Spectre.Console;

namespace ContactManager.View.States
{
    public class ExitState : BaseState, IState
    {
        public override Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            base.Execute(controller, stoppingToken);
            AnsiConsole.WriteLine("Exiting...");
            controller.Stop();
            stoppingToken.WaitHandle.WaitOne();
            return Task.CompletedTask;
        }
    }
}
