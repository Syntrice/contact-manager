using ContactManager.Model;
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

        public Task<Contact?> DeleteContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            var contacts = await _db.Contacts.AsNoTracking().ToListAsync();
            return contacts;
        }

        public Task<Contact?> GetContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public Task<Contact?> UpdateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
