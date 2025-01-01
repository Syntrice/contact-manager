using ContactManager.Data.Model;

namespace ContactManager.Data.Repository
{
    public interface IContactsRepository
    {
        public Task<IEnumerable<EmailAddressCategory>> GetEmailAddressCategoriesAsync();
        public Task<IEnumerable<PhoneNumberCategory>> GetPhoneNumberCategoriesAsync();
    }
}
