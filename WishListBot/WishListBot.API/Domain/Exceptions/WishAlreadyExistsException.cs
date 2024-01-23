namespace WishListBot.API.Domain.Exceptions
{
    public class WishAlreadyExistsException : Exception
    {
        // Конструктор с параметром
        public WishAlreadyExistsException(string wishName) : base($"Желание {wishName} уже существует в базе данных")
        {
        }
    }
}
