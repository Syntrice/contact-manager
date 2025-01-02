using ContactManager.ApplicationOptions;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace ContactManager.Data.Model
{
    public class ContactsDbContextFactory : IDesignTimeDbContextFactory<ContactsDbContext>
    {
        public ContactsDbContext CreateDbContext(string[] args)
        {
            DatabaseOptions options = new DatabaseOptions();
            options.DatabasePath = "ContactManager.db";
            IOptions<DatabaseOptions> databaseOptions = Options.Create(options);
            return new ContactsDbContext(databaseOptions);
        }
    }
}
