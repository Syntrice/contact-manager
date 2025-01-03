using ContactManager.Data.Model;

namespace ContactManager.Data.Repository
{
    public interface IContactsRepository
    {
        public Task AddContactAsync(Contact contact);
        public Task UpdateContactByIdAsync(int id, Contact updatedContact);
        public Task<Contact?> GetContactByIdAsync(int id);
        public Task DeleteContactByIdAsync(int id);
    }
}
