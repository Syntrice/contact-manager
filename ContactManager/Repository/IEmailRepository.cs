using ContactManager.Models;
using ContactManager.Models.EmailAddressModel;

namespace ContactManager.Repository
{
    public interface IEmailRepository
    {
        EmailAddress? AddEmailAddress(EmailAddress address);
        Task<IEnumerable<EmailAddress>> GetEmailAddressesAsync();
        Task<EmailAddress?> GetEmailAddressByIdAsync(int id);
        Task<EmailAddress?> UpdateEmailAddressAsync(EmailAddress emailAddress);
        Task<EmailAddress?> DeleteEmailAddressByIdAsync(int id);
        Task SaveAsync();
    }
}
