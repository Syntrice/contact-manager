using ContactManager.Logic;
using ContactManager.Model;
using Spectre.Console;

namespace ContactManager.View.States
{
    using ChoiceAction = (Func<IStateController, Task> Action, string Name);

    public class ManageContactsState : BaseState, IState
    {
        private readonly IContactsController _contactsController;
        public ManageContactsState(IContactsController contactsController)
        {
            _contactsController = contactsController;
        }

        public override async Task Execute(IStateController stateController, CancellationToken stoppingToken)
        {
            Clear();

            var response = await _contactsController.GetContactsAsync();

            List<ChoiceAction> _choices = new List<ChoiceAction>
            {
                ( (controller) => {controller.SetState(typeof(MainMenuState)); return Task.CompletedTask; }, "Back" ),
                ( async (controller) => await AddContact(controller), "Add New Contact" )
            };

            if (response.Type == ResponseType.Success)
            {
                List<ChoiceAction> contactChoices = response.Value.Select<Contact, ChoiceAction>(contact =>
                {
                    return (async (controller) => await EditContact(controller, contact), $"{contact.ContactId} - {contact.Name}");
                }).ToList();

                _choices.AddRange(contactChoices);
            }

            SelectionPrompt<ChoiceAction> _menu = new SelectionPrompt<ChoiceAction>()
                .Title("Manage Contacts")
                .AddChoices(_choices)
                .UseConverter(choice => choice.Name);

            var choice = await Task.Run(() => AnsiConsole.Prompt<ChoiceAction>(_menu));
            await choice.Action.Invoke(stateController);
        }

        public async Task EditContact(IStateController controller, Contact contact)
        {
            Clear();
            DispalyContactInformation(contact);

            AnsiConsole.WriteLine("Press any key to continue...");
            await Task.Run(() => Console.ReadKey());
        }

        public void DispalyContactInformation(Contact contact)
        {
            AnsiConsole.WriteLine($"Name: {contact.Name}");
            AnsiConsole.WriteLine($"Id: {contact.ContactId}");
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("Phone Numbers:");
            AnsiConsole.WriteLine(string.Join("\n", contact.PhoneNumbers.Select(x => $"{x.Category.Label}: {x.Number}")));
            AnsiConsole.WriteLine("Email Addresses:");
            AnsiConsole.WriteLine(string.Join("\n", contact.EmailAddresses.Select(x => $"{x.Category.Label}: {x.Address}")));
        }

        public async Task AddContact(IStateController controller)
        {
            Clear();
            string name = await Task.Run(() =>
            {
                return AnsiConsole.Prompt<string>(new TextPrompt<string>("Enter Contact Name:"));
            });

            var request = await _contactsController.CreateContactAsync(name);

            switch (request.Type)
            {
                case ResponseType.Success:
                    Console.WriteLine($"Successfuly added contact '{name}'");
                    break;
                case ResponseType.Failiure:
                    AnsiConsole.MarkupLine($"[red]{request.Message}[/]");
                    break;
            }

            AnsiConsole.WriteLine("Press any key to continue...");
            await Task.Run(() => Console.ReadKey());
        }


    }
}
