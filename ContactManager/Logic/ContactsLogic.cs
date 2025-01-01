using ContactManager.Data.Repository;

namespace ContactManager.Logic
{
    public class ContactsLogic : IContactsLogic
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsLogic(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task<List<string>> GetEmailAddressCategoryLabelsAsync()
        {
            var categories = await _contactsRepository.GetEmailAddressCategoriesAsync();
            return categories.Select(c => c.Label).ToList();
        }

        public async Task<List<string>> GetPhoneNumberCategoryLabelsAsync()
        {
            var categories = await _contactsRepository.GetPhoneNumberCategoriesAsync();
            return categories.Select(c => c.Label).ToList();    
        }
    }
}
