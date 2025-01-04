using ContactManager.Data.Model;
using ContactManager.Logic;
using Spectre.Console;

namespace ContactManager.View.States
{
    public class ContactsBrowseState : BaseState, IState
    {
        private IContactsLogic _contactsLogic;
        public ContactsBrowseState(IContactsLogic contactsLogic)
        {
            _contactsLogic = contactsLogic;
        }

        public override Task Execute(IStateController controller, CancellationToken stoppingToken)
        {
            Clear();
            return Task.CompletedTask;
        }
    }
}
