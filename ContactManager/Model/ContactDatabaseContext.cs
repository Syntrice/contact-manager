using ContactManager.Options;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Model
{
    public class ContactDatabaseContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<PhoneNumber> PhoneNumbers { get; set; } = null!;

        public DbSet<EmailAddress> Emails { get; set; } = null!;

        public DbSet<PhoneNumberCategory> PhoneNumberCategories { get; set; } = null!;

        public DbSet<EmailAddressCategory> EmailAddressCategories { get; set; } = null!;

        public ContactDatabaseContext(DatabaseOptions databaseOptions)
        {
            DbPath = databaseOptions.DatabasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
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
    }
}
