namespace WishListBot.API.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string User) : base($"Пользователь: {User} не найден")
        {
        }
    }
}
