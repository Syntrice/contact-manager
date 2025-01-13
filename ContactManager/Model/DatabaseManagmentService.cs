using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContactManager.Model
{
    public class DatabaseManagmentService : IHostedService
    {
        private readonly ContactsDbContext _dbContext;
        private readonly ILogger _logger;

        public DatabaseManagmentService(ContactsDbContext context, ILogger<DatabaseManagmentService> logger)
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
