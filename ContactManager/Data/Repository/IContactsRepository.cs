using ContactManager.Data.Model;

namespace ContactManager.Data.Repository
{
    public interface IContactsRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact?> GetContactByIdAsync(int contactId);
        Contact? AddContact(Contact contact);
        Task<Contact?> DeleteContactAsync(int contactId);
        Task<Contact?> UpdateContactAsync(Contact contact);
        Task SaveAsync();
    }
}
