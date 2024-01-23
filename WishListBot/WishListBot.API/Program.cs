using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WishListBot.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var client = new TelegramBotClient(builder.Configuration["BotConfiguration:BotToken"]);
            client.SetWebhookAsync(builder.Configuration["BotConfiguration:WebhookUrl"]).Wait();
            // Добавляем сервис TelegramBotClient, который позволяет работать с Telegram Bot API
            builder.Services.AddSingleton<ITelegramBotClient>(client);

            var app = builder.Build();
            if(!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            // Добавляем маршрут для POST-запроса по адресу /api/message/update, который обрабатывает обновления от Telegram Bot API
            app.MapPost("/", async (HttpContext httpContext, ITelegramBotClient botClient) =>
            {
                var update = JsonConvert.DeserializeObject<Update>(httpContext.Request.ReadFromJsonAsync<object>().Result.ToString());
                if(update == null)
                {
                    return;
                }
                switch(update.Type)
                {
                    case UpdateType.Message:
                        await HandleMessageAsync(update.Message, botClient);
                        break;
                        // Добавляем другие типы обновлений
                }
            });

            app.Run();
        }
        // Асинхронный метод для обработки различных типов сообщений
        static async Task HandleMessageAsync(Message message, ITelegramBotClient botClient)
        {
            // Выводим в консоль информацию о полученном сообщении
            Console.WriteLine($"Received a message from {message.From.FirstName} {message.From.LastName}");

            switch(message.Type)
            {
                case MessageType.Text:
                    await HandleTextMessageAsync(message, botClient);
                    break;
                    // Добавляем другие типы сообщений
            }
        }
        public static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for(int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

        // Асинхронный метод для обработки текстовых сообщений и команд
        static async Task HandleTextMessageAsync(Message message, ITelegramBotClient botClient)
        {
            string response;

            switch(message.Text.ToLower())
            {
                case "/start":
                    response = "Hello, I am a Telegram bot created by Bing. I can do some cool things for you.";
                    break;
                case "/help":
                    response = "You can use the following commands:\n/start - Start the conversation\n/help - Get help information\n/echo - Repeat your message\n/time - Get the current time";
                    break;
                case "/echo":
                    response = "Я не понимать тебя!!!!!!! ";
                    break;
                case "/time":
                    response = $"The current time is {DateTime.Now}";
                    break;
                default:
                    if(message.Text.StartsWith("/echo "))
                    {
                        response = message.Text.Substring(6);
                    }
                    // Иначе говорим, что не понимаем команду и предлагаем посмотреть список команд
                    else
                    {
                        response =  $"Что ты хочешь??? опять издеваешься. Ну ладно вот Твоя строка на оборот [{Reverse(message.Text)}] ";
                    }
                    break;
            }

            // Отправляем ответ пользователю
            await botClient.SendTextMessageAsync(message.Chat.Id, response);
        }
    }
}
