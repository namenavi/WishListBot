using Microsoft.AspNetCore.HttpOverrides;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.Extensions.DependencyInjection;
using WishListBot.API.Infrastructure.Settings;
using WishListBot.API.Infrastructure.Services;

namespace WishListBot.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var botConfig = builder.Configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
            builder.Services.AddHostedService<ConfigureWebhook>();
            if(botConfig != null)
            {
                builder.Services.AddHttpClient("tgwebhook")
                    .AddTypedClient<ITelegramBotClient>(httpClient
                        => new TelegramBotClient(botConfig.BotToken, httpClient));
            }
            builder.Services.AddScoped<HandleUpdateService>();
            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddApplicationInsightsTelemetry();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            //app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if(botConfig != null)
            {
                var token = botConfig.BotToken;
                var url = $"bot/{token}";
                app.MapControllerRoute("webhooktelegram", url, defaults:
                    new { controller = "Webhook", action = "Post" });
            }

            app.MapControllers();

            app.Run();
        }
    }
}
