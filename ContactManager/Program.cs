using ContactManager.Model;
using ContactManager.Options;
using ContactManager.Services;
using ContactManager.UI;
using ContactManager.UI.States;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(DatabaseOptions.SectionName)); 
builder.Services.AddDbContext<ContactDatabaseContext>();
builder.Services.AddHostedService<DatabaseManagmentService>();
builder.Services.AddHostedService<ConsoleUIService>();
builder.Services.AddTransient<IUIStateFactory, UIStateFactory>();
builder.Services.AddTransient<IUIState, MainMenuState>();
builder.Services.AddTransient<IUIState, TestState>();
builder.Logging.ClearProviders();
builder.Logging.AddDebug();
IHost host = builder.Build();
await host.StartAsync();
await host.StopAsync();