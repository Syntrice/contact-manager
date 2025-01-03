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

        public async Task<Contact?> DeleteContactAsync(int contactId)
        {
            Contact? contact = await _db.Contacts.FindAsync(contactId);

            if (contact != null)
            {
                _db.Contacts.Remove(contact);
            }

            return contact;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            List<Contact> contacts = await _db.Contacts.AsNoTracking().ToListAsync();
            return contacts;
        }

        public async Task<Contact?> GetContactByIdAsync(int contactId)
        {
            Contact? contact = await _db.Contacts.AsNoTracking().SingleOrDefaultAsync(c => c.ContactId == contactId);
            return contact;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Contact?> UpdateContactAsync(Contact contact)
        {
            Contact? contactToUpdate = await _db.Contacts.FindAsync(contact.ContactId);

            if (contactToUpdate != null)
            {
                    contactToUpdate.Name = contact.Name;
                    contactToUpdate.EmailAddresses = contact.EmailAddresses;
                    contactToUpdate.PhoneNumbers = contact.PhoneNumbers;
            }

            return contactToUpdate;
        }
    }
}
