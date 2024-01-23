namespace WishListBot.API.Domain.Exceptions
{
    /// <summary>
    /// Класс, который представляет исключение, что желание не найдено
    /// </summary>
    public class WishNotFoundException : Exception
    {
        /// <summary>
        /// Конструктор, который принимает номер желания
        /// </summary>
        /// <param name="number"></param>
        public WishNotFoundException(int number) : base($"Желание с номером {number} не найдено")
        {
        }

        /// <summary>
        /// Конструктор, который принимает идентификатор желания
        /// </summary>
        /// <param name="id"></param>
        public WishNotFoundException(string id) : base($"Желание с идентификатором {id} не найдено")
        {
        }
    }
}
