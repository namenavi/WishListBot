namespace WishListBot.API.Presentation.Models
{
    public class TelegramResponse
    {
        // Свойство для хранения текста ответа
        public string Text { get; set; }

        // Конструктор с параметром
        public TelegramResponse(string text)
        {
            Text = text;
        }
    }
}
