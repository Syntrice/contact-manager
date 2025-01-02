using ContactManager.Data.Model;

namespace ContactManager.Data.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsDbContext _context;
        public ContactsRepository(ContactsDbContext context)
        {
            _context = context;
        }
    }
}
