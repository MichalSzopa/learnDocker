
namespace TodoApi.Services.Services
{
	public class NotificationWorker : BackgroundService
	{
		//private readonly ITaskService taskService;
		private readonly ILogger<NotificationWorker> logger;

		public NotificationWorker(/*ITaskService taskService,*/ ILogger<NotificationWorker> logger)
		{
			// this.taskService = taskService;
			this.logger = logger;
		}
		protected async override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				// await taskService.SendNotifications();
				logger.LogInformation("Worker running at time {time}", DateTimeOffset.Now);
				await Task.Delay(/*300000*/ 1000, stoppingToken);
			}
		}
	}
}
