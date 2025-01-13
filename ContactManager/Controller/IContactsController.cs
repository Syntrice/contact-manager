using ContactManager.Model;

namespace ContactManager.Logic
{
    public interface IContactsController
    {
        Task<Response> CreateContactAsync(string name);
        Task<Response<List<Contact>>> GetContactsAsync();
    }
}
