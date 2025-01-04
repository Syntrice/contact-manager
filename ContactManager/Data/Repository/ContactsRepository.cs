using ContactManager.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsDbContext _db;
        public ContactsRepository(ContactsDbContext context)
        {
            _db = context;
        }

        public Contact? AddContact(Contact contact)
        {
            _db.Contacts.Add(contact);
            return contact;
        }

        public EmailAddress? AddEmailAddress(EmailAddress address)
        {
            throw new NotImplementedException();
        }

        public EmailAddressCategory? AddEmailAddressCategory(EmailAddressCategory category)
        {
            throw new NotImplementedException();
        }

        public PhoneNumber? AddPhoneNumber(PhoneNumber phoneNumber)
        {
            throw new NotImplementedException();
        }

        public PhoneNumberCategory? AddPhoneNumberCategory(PhoneNumberCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<Contact?> DeleteContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmailAddress?> DeleteEmailAddressByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmailAddressCategory?> DeleteEmailAddressCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneNumber?> DeletePhoneNumberByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneNumberCategory?> DeletePhoneNumberCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            var contacts = await _db.Contacts.AsNoTracking().ToListAsync();
            return contacts;
        }

        public Task<IEnumerable<EmailAddressCategory>> GetAllEmailAddressCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmailAddress>> GetAllEmailAddressesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PhoneNumberCategory>> GetAllPhoneNumberCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PhoneNumber>> GetAllPhoneNumbersAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact?> GetContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmailAddress?> GetEmailAddressByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmailAddressCategory?> GetEmailAddressCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneNumber?> GetPhoneNumberByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneNumberCategory?> GetPhoneNumberCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact?> UpdateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<EmailAddress?> UpdateEmailAddressAsync(EmailAddress emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<EmailAddressCategory?> UpdateEmailAddressCategoryAsync(EmailAddressCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneNumber?> UpdatePhoneNumberAsync(PhoneNumber phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneNumberCategory?> UpdatePhoneNumberCategoryAsync(PhoneNumberCategory category)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
