using ContactManager.Data.Model;
using ContactManager.Data.Repository;
using ContactManager.Data.Validation;

namespace ContactManager.Logic
{
    public class ContactsLogic : IContactsLogic
    {
        private readonly IContactsRepository _repo;
        private readonly ContactValidator _contactValidator;

        public ContactsLogic(IContactsRepository contactsRepository)
        {
            _repo = contactsRepository;
            _contactValidator = new ContactValidator();
        }

        public async Task<Response> CreateContactAsync(string name)
        {
            Contact contact = new Contact() { Name = name };
            var validation = _contactValidator.Validate(contact);

            if (!validation.IsValid)
            {
                return Response.Failiure(validation.ToString());
            }

            _repo.AddContact(contact);
            await _repo.SaveAsync();
            return Response.Success();
        }

        public Task<Response<List<Contact>>> GetContactsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
