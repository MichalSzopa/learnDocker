
namespace TodoApi.Services.Services
{
	public class NotificationWorker : BackgroundService
	{
		private readonly IServiceProvider serviceProvider;
		private readonly ILogger<NotificationWorker> logger;

		public NotificationWorker(IServiceProvider serviceProvider, ILogger<NotificationWorker> logger)
		{
			this.serviceProvider = serviceProvider;
			this.logger = logger;
		}
		protected async override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				using (var scope = serviceProvider.CreateScope())
				{
					var taskService = scope.ServiceProvider.GetRequiredService<ITaskService>();
					await taskService.SendNotifications();
					logger.LogInformation("Worker running at time {time}", DateTimeOffset.Now);
					await Task.Delay(60 * 1000, stoppingToken);
				}
			}
		}
	}
}
