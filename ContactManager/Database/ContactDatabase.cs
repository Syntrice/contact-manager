using Microsoft.EntityFrameworkCore;

namespace ContactManager.Database
{
    public class ContactDatabase : DbContext
    {
        public string DbPath { get; }

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<PhoneNumber> PhoneNumbers { get; set; } = null!;

        public DbSet<EmailAddress> Emails { get; set; } = null!;

        public DbSet<PhoneNumberCategory> PhoneNumberCategories { get; set; } = null!;

        public DbSet<EmailAddressCategory> EmailAddressCategories { get; set; } = null!;

        public ContactDatabase()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "contacts.db");
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

        public static void ApplyMigrations()
        {
            /*
            TODO:
                - call backup database method here
                - handle corrupted database
             */
            using (var db = new ContactDatabase())
            {
                db.Database.Migrate();
            }
        }
    }
}
