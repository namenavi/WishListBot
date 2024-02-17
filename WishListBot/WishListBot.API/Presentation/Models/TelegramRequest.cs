using Newtonsoft.Json;
using Telegram.Bot.Types;
using WishListBot.API.ApplicationBLL.DTOs;

namespace WishListBot.API.Presentation.Models
{
    public class TelegramRequest
    {
        // Свойство для хранения сообщения из запроса
        [JsonProperty("message")]
        public Message Message { get; set; }

    }

}
