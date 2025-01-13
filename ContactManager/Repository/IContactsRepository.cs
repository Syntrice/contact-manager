using ContactManager.Model;

namespace ContactManager.Repository
{
    public interface IContactsRepository
    {
        Contact? AddContact(Contact contact);
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact?> GetContactByIdAsync(int id);
        Task<Contact?> UpdateContactAsync(Contact contact);
        Task<Contact?> DeleteContactByIdAsync(int id);
        Task SaveAsync();
    }
}
