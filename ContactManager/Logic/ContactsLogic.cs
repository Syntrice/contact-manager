using ContactManager.Data.Repository;

namespace ContactManager.Logic
{
    public class ContactsLogic
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsLogic(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }
    }
}
