using Microsoft.Extensions.Options;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using WishListBot.API.ApplicationBLL.DTOs;
using WishListBot.API.ApplicationBLL.Interfaces;
using Telegram.Bot.Types;
using WishListBot.API.Presentation.Models;
using WishListBot.API.Infrastructure.Settings;

namespace WishListBot.API.Infrastructure.Services
{
    public class TelegramService : ITelegramService
    {
        ////// Свойство для хранения клиента телеграмм
        ////private readonly TelegramBotClient _client;

        ////// Свойство для хранения настроек телеграмм
        ////private readonly TelegramSettings _settings;

        ////// Конструктор с параметрами
        ////public TelegramService(IOptions<TelegramSettings> options)
        ////{
        ////    // Получаем настройки из параметров
        ////    _settings = options.Value;

        ////    // Создаем клиента телеграмм с токеном из настроек
        ////    _client = new TelegramBotClient(_settings.Token);
        ////}

        ////// Метод для отправки сообщения пользователю
        ////public async Task SendMessageAsync(User user, string message)
        ////{
        ////    // Проверяем, что пользователь и сообщение не пустые
        ////    if(user == null || string.IsNullOrEmpty(message))
        ////    {
        ////        return;
        ////    }

        ////    // Отправляем сообщение пользователю с помощью клиента телеграмм
        ////    await _client.SendTextMessageAsync(user.Id, message, null ,ParseMode.Markdown);
        ////}

        ////// Метод для получения запроса от пользователя
        ////public async Task<TelegramRequest> GetRequestAsync(Update update)
        ////{
        ////    // Проверяем, что обновление не пустое и имеет тип сообщения
        ////    if(update == null || update.Type != UpdateType.Message)
        ////    {
        ////        return null;
        ////    }

        ////    // Получаем сообщение из обновления
        ////    var message = update.Message;

        ////    // Проверяем, что сообщение не пустое и имеет тип текста
        ////    if(message == null || message.Type != MessageType.Text)
        ////    {
        ////        return null;
        ////    }

        ////    // Создаем запрос из сообщения
        ////    var request = new TelegramRequest
        ////    {
        ////        User = new UserDto
        ////        {
        ////            Id = ((int)message.From.Id),
        ////            Name = message.From.Username
        ////        },
        ////        Text = message.Text
        ////    };

        ////    // Возвращаем запрос
        ////    return request;
        ////}
    }
}
