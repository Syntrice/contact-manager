using ContactManager.Models.ContactModel;
using ContactManager.Wrappers;

namespace ContactManager.Services
{
    public interface IContactService
    {
        Task<ServiceResponse> CreateContactAsync(string name);
        Task<ServiceObjectResponse<List<Contact>>> GetContactsAsync();
    }
}
