using ContactManager.Model;
using ContactManager.Model.Validation;
using ContactManager.Repository;
using FluentValidation.Results;

namespace ContactManager.Logic
{
    public class ContactsController : IContactsController
    {
        private readonly IContactsRepository _repo;
        private readonly ContactValidator _contactValidator;

        public ContactsController(IContactsRepository contactsRepository)
        {
            _repo = contactsRepository;
            _contactValidator = new ContactValidator();
        }

        public async Task<Response> CreateContactAsync(string name)
        {
            Contact contact = new Contact() { Name = name };
            ValidationResult validation = _contactValidator.Validate(contact);

            if (!validation.IsValid)
            {
                return Response.Failiure(validation.ToString());
            }

            _repo.AddContact(contact);
            await _repo.SaveAsync();
            return Response.Success();
        }

        public async Task<Response<List<Contact>>> GetContactsAsync()
        {
            List<Contact> contacts = (await _repo.GetAllContactsAsync()).ToList();
            if (contacts.Count == 0)
            {
                return Response<List<Contact>>.Failiure("No contacts in repository.", contacts);
            }
            return Response<List<Contact>>.Success(contacts);
        }
    }
}
