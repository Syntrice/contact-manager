using ContactManager.Database;

ContactDatabase.ApplyMigrations();

using (var db = new ContactDatabase())
{
    Console.WriteLine("Email Address Categories:");
    foreach (var category in db.EmailAddressCategories)
    {
        Console.WriteLine(category.Label);
    }

    Console.WriteLine("Phone Number Categories:");
    foreach (var category in db.PhoneNumberCategories)
    {
        Console.WriteLine(category.Label);
    }
}