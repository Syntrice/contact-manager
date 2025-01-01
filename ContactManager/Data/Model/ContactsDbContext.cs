using ContactManager.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ContactManager.Data.Model
{
    public class ContactsDbContext : DbContext
    {
        private DatabaseOptions _options;

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<PhoneNumber> PhoneNumbers { get; set; } = null!;

        public DbSet<EmailAddress> Emails { get; set; } = null!;

        public DbSet<PhoneNumberCategory> PhoneNumberCategories { get; set; } = null!;

        public DbSet<EmailAddressCategory> EmailAddressCategories { get; set; } = null!;

        public ContactsDbContext(IOptions<DatabaseOptions> databaseOptions)
        {
            _options = databaseOptions.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={_options.DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailAddressCategory>(e =>
            {
                e.HasData(EmailAddressCategory.GetDefaultEmailAddressCategories());
            });

            modelBuilder.Entity<PhoneNumberCategory>(e =>
            {
                e.HasData(PhoneNumberCategory.GetDefaultPhoneNumberCategories());
            });
        }

        public async Task Migrate()
        {
            await Database.MigrateAsync();
        }
    }
}
