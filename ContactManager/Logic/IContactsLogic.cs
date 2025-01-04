using ContactManager.Data.Model;

namespace ContactManager.Logic
{
    public interface IContactsLogic
    {
        Task<Response> CreateContactAsync(string name);
        Task<Response<List<Contact>>> GetContactsAsync();
    }
}
