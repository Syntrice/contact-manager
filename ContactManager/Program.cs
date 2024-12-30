using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ContactManager.Options;
using ContactManager.Model;
using ContactManager.Services;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(DatabaseOptions.SectionName)); 
builder.Services.AddDbContext<ContactDatabaseContext>();
builder.Services.AddHostedService<DatabaseManagmentService>();
builder.Logging.ClearProviders();
builder.Logging.AddDebug();
IHost host = builder.Build();
host.Run();

//ContactDatabase.ApplyMigrations();

//using (var db = new ContactDatabase())
//{
//    Console.WriteLine("Email Address Categories:");
//    foreach (var category in db.EmailAddressCategories)
//    {
//        Console.WriteLine(category.Label);
//    }

//    Console.WriteLine("Phone Number Categories:");
//    foreach (var category in db.PhoneNumberCategories)
//    {
//        Console.WriteLine(category.Label);
//    }
//}