namespace WishListBot.API.Domain.Exceptions
{
    // Класс, который представляет исключение, что желание не найдено
    public class WishNotFoundException : Exception
    {
        // Конструктор, который принимает номер желания
        public WishNotFoundException(int number) : base($"Желание с номером {number} не найдено")
        {
        }

        // Конструктор, который принимает идентификатор желания
        public WishNotFoundException(string id) : base($"Желание с идентификатором {id} не найдено")
        {
        }
    }
}
