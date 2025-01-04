using ContactManager.Data.Model;

namespace ContactManager.Data.Repository
{
    public interface IContactsRepository
    {

        // CREATE
        Contact? AddContact(Contact contact);

        PhoneNumber? AddPhoneNumber(PhoneNumber phoneNumber);

        EmailAddress? AddEmailAddress(EmailAddress address);

        EmailAddressCategory? AddEmailAddressCategory(EmailAddressCategory category);

        PhoneNumberCategory? AddPhoneNumberCategory(PhoneNumberCategory category);

        // READ
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact?> GetContactByIdAsync(int id);

        Task<IEnumerable<PhoneNumber>> GetAllPhoneNumbersAsync(int id);
        Task<PhoneNumber?> GetPhoneNumberByIdAsync(int id);

        Task<IEnumerable<EmailAddress>> GetAllEmailAddressesAsync();
        Task<EmailAddress?> GetEmailAddressByIdAsync(int id);

        Task<IEnumerable<PhoneNumberCategory>> GetAllPhoneNumberCategoriesAsync();
        Task<PhoneNumberCategory?> GetPhoneNumberCategoryByIdAsync(int id);

        Task<IEnumerable<EmailAddressCategory>> GetAllEmailAddressCategoriesAsync();
        Task<EmailAddressCategory?> GetEmailAddressCategoryByIdAsync(int id);

        // UPDATE
        Task<Contact?> UpdateContactAsync(Contact contact);

        Task<PhoneNumber?> UpdatePhoneNumberAsync(PhoneNumber phoneNumber);

        Task<EmailAddress?> UpdateEmailAddressAsync(EmailAddress emailAddress);

        Task<PhoneNumberCategory?> UpdatePhoneNumberCategoryAsync(PhoneNumberCategory category);

        Task<EmailAddressCategory?> UpdateEmailAddressCategoryAsync(EmailAddressCategory category);

        // DELETE
        Task<Contact?> DeleteContactByIdAsync(int id);

        Task<PhoneNumber?> DeletePhoneNumberByIdAsync(int id);

        Task<EmailAddress?> DeleteEmailAddressByIdAsync(int id);

        Task<PhoneNumberCategory?> DeletePhoneNumberCategoryByIdAsync(int id);

        Task<EmailAddressCategory?> DeleteEmailAddressCategoryByIdAsync(int id);


        Task SaveAsync();
    }
}
