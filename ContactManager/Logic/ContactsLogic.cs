using ContactManager.Data.Model;
using ContactManager.Data.Repository;

namespace ContactManager.Logic
{
    public class ContactsLogic : IContactsLogic
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsLogic(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public Task<Response> CreateContactAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Contact>>> GetContactsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
