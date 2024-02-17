namespace WishListBot.API.ApplicationBLL.DTOs
{
    // Класс, который представляет объект передачи данных для пользователя
    public class UserDto
    {
        // Свойство для хранения идентификатора пользователя
        public int Id { get; set; }
        // Свойство, которое хранит имя пользователя
        public string Name { get; set; }

        // Свойство, которое хранит список желаний пользователя
        public List<WishDto> Wishes { get; set; }
    }
}
