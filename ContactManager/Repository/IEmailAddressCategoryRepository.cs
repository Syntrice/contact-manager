using ContactManager.Model;

namespace ContactManager.Repository
{
    public interface IEmailAddressCategoryRepository
    {
        EmailAddressCategory? AddEmailAddressCategory(EmailAddressCategory category);
        Task<IEnumerable<EmailAddressCategory>> GetEmailAddressCategoriesAsync();
        Task<EmailAddressCategory?> GetEmailAddressCategoryByIdAsync(int id);
        Task<EmailAddressCategory?> UpdateEmailAddressCategoryAsync(EmailAddressCategory category);
        Task<EmailAddressCategory?> DeleteEmailAddressCategoryByIdAsync(int id);
        Task SaveAsync();
    }
}
