using ContactManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContactManager.Services
{
    public class DatabaseManagmentService : IHostedService
    {
        private readonly IContactDatabaseContext _dbContext;
        private readonly ILogger _logger;

        public DatabaseManagmentService(IContactDatabaseContext context, ILogger<DatabaseManagmentService> logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StartAsync has been called");
            await MigrateDatabaseAsync();
        }


        private async Task MigrateDatabaseAsync()
        {
            _logger.LogInformation("Attempting to migrate ContactDatabase");

            // todo: error handling
            await _dbContext.Migrate();

            _logger.LogInformation("Migration completed");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StopAsync has been called");
            return Task.CompletedTask;
        }
    }
}
