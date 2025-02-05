using ContactManager.Database;
using ContactManager.Models;
using ContactManager.Models.ContactModel;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Repository
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

        public async Task<Contact?> DeleteContactByIdAsync(int id)
        {
            // Check if contact exists
            Contact? contact = await _db.Contacts.FindAsync(id);

            if (contact != null)
            {
                _db.Contacts.Remove(contact);
            }

            return contact;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            var contacts = await _db.Contacts.AsNoTracking().ToListAsync();
            return contacts;
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _db.Contacts.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Contact?> UpdateContactAsync(Contact contact)
        {
            Contact? existingContact = await _db.Contacts.FindAsync(contact.ContactId);

            if (existingContact != null)
            {
                _db.Entry(existingContact).CurrentValues.SetValues(contact);
            }

            return existingContact;
        }
    }
}
