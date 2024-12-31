using ContactManager.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ContactManager.Model
{
    public interface IContactDatabaseContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<EmailAddressCategory> EmailAddressCategories { get; set; }
        DbSet<EmailAddress> Emails { get; set; }
        DbSet<PhoneNumberCategory> PhoneNumberCategories { get; set; }
        DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public Task Migrate();
    }

    public class ContactDatabaseContext : DbContext, IContactDatabaseContext
    {
        private DatabaseOptions _options;

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<PhoneNumber> PhoneNumbers { get; set; } = null!;

        public DbSet<EmailAddress> Emails { get; set; } = null!;

        public DbSet<PhoneNumberCategory> PhoneNumberCategories { get; set; } = null!;

        public DbSet<EmailAddressCategory> EmailAddressCategories { get; set; } = null!;

        public ContactDatabaseContext(IOptions<DatabaseOptions> databaseOptions)
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
