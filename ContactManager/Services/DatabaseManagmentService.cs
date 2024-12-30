using ContactManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContactManager.Services
{
    public class DatabaseManagmentService : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly ContactDatabaseContext _dbContext;
        private readonly ILogger _logger;

        public DatabaseManagmentService(ContactDatabaseContext context, ILogger<DatabaseManagmentService> logger, IHostApplicationLifetime lifetime)
        {
            _dbContext = context;
            _logger = logger;
            _appLifetime = lifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("DatabaseManagementService: StartAsync has been called");

            _appLifetime.ApplicationStarted.Register(OnApplicationStarted);
            _appLifetime.ApplicationStopping.Register(OnApplicationStopping);
            _appLifetime.ApplicationStopped.Register(OnApplicationStoped);

            return Task.CompletedTask;
        }

        public void OnApplicationStarted()
        {
            _logger.LogInformation("DatabaseManagementService: OnApplicationStarted has been called");
            MigrateDatabase();
        }

        private void MigrateDatabase()
        {
            _logger.LogInformation("DatabaseManagementService: Attempting to migrate ContactDatabase");

            // todo: error handling
            _dbContext.Database.Migrate();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("DatabaseManagementService StopAsync has been called");
            return Task.CompletedTask;
        }

        public void OnApplicationStopping()
        {
            _logger.LogInformation("DatabaseManagementService: OnApplicationStopping has been called");
        }

        public void OnApplicationStoped()
        {
            _logger.LogInformation("DatabaseManagementService: OnApplicationStoped has been called");
        }
    }
}
