using ContactManager.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsDbContext _context;
        public ContactsRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmailAddressCategory>>GetEmailAddressCategoriesAsync()
        {
            return await _context.EmailAddressCategories.ToListAsync();
        }

        public async Task<IEnumerable<PhoneNumberCategory>> GetPhoneNumberCategoriesAsync()
        {
            return await _context.PhoneNumberCategories.ToListAsync();
        }
    }
}
