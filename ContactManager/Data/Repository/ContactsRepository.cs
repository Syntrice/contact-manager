using ContactManager.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsDbContext _context;
        public ContactsRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.AsNoTracking().SingleAsync(c => c.ContactId == id);
        }

        public async Task<List<Contact>> GetAllContextsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task UpdateContactByIdAsync(int id, Contact updatedContact)
        {
            Contact? contactToUpdate = await _context.Contacts.FindAsync(id);

            // TODO: Handle null contactToUpdate
            if (contactToUpdate == null)
            {
                return;
            }

            contactToUpdate.Name = updatedContact.Name;
            contactToUpdate.PhoneNumbers = updatedContact.PhoneNumbers;
            contactToUpdate.EmailAddresses = updatedContact.EmailAddresses;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactByIdAsync(int id)
        {
            Contact? contact = await _context.Contacts.FindAsync(id);

            // TODO: Handle null contactToUpdate
            if (contact == null)
            {
                return;
            }

            _context.Contacts.Remove(contact);  
            await _context.SaveChangesAsync();
        }
    }
}
