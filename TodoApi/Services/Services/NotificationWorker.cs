using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Services.Services;

public class NotificationWorker(IServiceProvider serviceProvider, ILogger<NotificationWorker> logger)
	: BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			using var scope = serviceProvider.CreateScope();
			var taskService = scope.ServiceProvider.GetRequiredService<ITaskService>();
			await taskService.SendNotifications();
			logger.LogInformation("Worker running at time {time}", DateTimeOffset.Now);
			await Task.Delay(60 * 1000, stoppingToken);
		}
	}
}