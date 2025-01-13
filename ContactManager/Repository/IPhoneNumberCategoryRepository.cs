using ContactManager.Model;

namespace ContactManager.Repository
{
    public interface IPhoneNumberCategoryRepository
    {
        PhoneNumberCategory? AddPhoneNumberCategory(PhoneNumberCategory category);
        Task<IEnumerable<PhoneNumberCategory>> GetPhoneNumberCategoriesAsync();
        Task<PhoneNumberCategory?> GetPhoneNumberCategoryByIdAsync(int id);
        Task<PhoneNumberCategory?> UpdatePhoneNumberCategoryAsync(PhoneNumberCategory category);
        Task<PhoneNumberCategory?> DeletePhoneNumberCategoryByIdAsync(int id);
        Task SaveAsync();
    }
}
