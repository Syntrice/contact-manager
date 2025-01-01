using ContactManager.Data.Model;
using ContactManager.Data.Repository;
using ContactManager.Logic;
using ContactManager.Options;
using ContactManager.View;
using ContactManager.View.States;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(DatabaseOptions.SectionName)); 
builder.Services.Configure<ConsoleUIOptions>(options => options.StartingState = typeof(MainMenuState));
builder.Services.AddDbContext<ContactsDbContext>();
builder.Services.AddHostedService<DatabaseManagmentService>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IContactsLogic, ContactsLogic>();
builder.Services.AddHostedService<ConsoleUIService>();
builder.Services.AddTransient<IState, MainMenuState>();
builder.Services.AddTransient<IState, TestState>();
builder.Services.AddTransient<IState, ExitState>();
builder.Logging.ClearProviders();
builder.Logging.AddDebug();
IHost host = builder.Build();
await host.RunAsync();