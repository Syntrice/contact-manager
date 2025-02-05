using ContactManager.Models.ContactModel;
using ContactManager.Repository;
using ContactManager.Wrappers;
using FluentValidation.Results;

namespace ContactManager.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactsRepository _repo;
        private readonly ContactValidator _contactValidator;

        public ContactService(IContactsRepository contactsRepository)
        {
            _repo = contactsRepository;
            _contactValidator = new ContactValidator();
        }

        public async Task<ServiceResponse> CreateContactAsync(string name)
        {
            Contact contact = new Contact() { Name = name };
            ValidationResult validation = _contactValidator.Validate(contact);

            if (!validation.IsValid)
            {
                return ServiceResponse.Failiure(validation.ToString());
            }

            _repo.AddContact(contact);
            await _repo.SaveAsync();
            return ServiceResponse.Success();
        }

        public async Task<ServiceObjectResponse<List<Contact>>> GetContactsAsync()
        {
            List<Contact> contacts = (await _repo.GetContactsAsync()).ToList();
            if (contacts.Count == 0)
            {
                return ServiceObjectResponse<List<Models.ContactModel.Contact>>.Failiure("No contacts in repository.", contacts);
            }
            return ServiceObjectResponse<List<Models.ContactModel.Contact>>.Success(contacts);
        }
    }
}
