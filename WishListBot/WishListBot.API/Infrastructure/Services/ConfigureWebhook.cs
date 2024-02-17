using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using WishListBot.API.Infrastructure.Settings;

namespace WishListBot.API.Infrastructure.Services
{
    public class ConfigureWebhook : IHostedService
    {
        private readonly ILogger<ConfigureWebhook> _logger;
        private readonly IServiceProvider _services;
        private readonly BotConfiguration _botConfig;
        private ITelegramBotClient _botClient;

        public ConfigureWebhook(ILogger<ConfigureWebhook> logger,
                                IServiceProvider serviceProvider,
                                IConfiguration configuration)
        {
            _logger = logger;
            _services = serviceProvider;
            _botConfig = configuration.GetSection("BotConfiguration").Get<BotConfiguration>()!;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _services.CreateScope();
            _botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            var webhookAddress = @$"{_botConfig.HostAddress}bot/{_botConfig.BotToken}"; ///
            _logger.LogInformation("Setting webhook: {webhookAddress}", webhookAddress);
            await _botClient.SetWebhookAsync(
                url: webhookAddress,
                allowedUpdates: Array.Empty<UpdateType>(),
                cancellationToken: cancellationToken);
            _logger.LogInformation("Setting webhook success");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _botClient.DeleteWebhookAsync();
            _logger.LogInformation("Do nothing");
            return Task.CompletedTask;
        }
    }
}
