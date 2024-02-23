using Microsoft.AspNetCore.HttpOverrides;
using Telegram.Bot;
using WishListBot.API.Infrastructure.Settings;
using WishListBot.API.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using WishListBot.API.ApplicationBLL.Interfaces;
using WishListBot.API.Infrastructure.Persistence;
using WishListBot.API.Domain.Interfaces;

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
            string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));
            builder.Services.AddScoped<HandleUpdateService>();
            builder.Services.AddScoped<IWishService, WishService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IUserRepository, WishService>();
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            var app = builder.Build();


            app.UseRouting();

            if(botConfig != null)
            {
                var token = botConfig.BotToken;
                var url = $"";//bot/{token}
                app.MapControllerRoute("webhooktelegram", url, defaults:
                    new { controller = "Webhook", action = "Post" });
            }

            app.MapControllers();

            app.Run();
        }
    }
}
