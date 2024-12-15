using Microsoft.EntityFrameworkCore;

namespace ContactManager.Database
{
    public class ContactDatabase : DbContext
    {
        DbSet<Contact> Contacts { get; set; } = null!;
    }
}
