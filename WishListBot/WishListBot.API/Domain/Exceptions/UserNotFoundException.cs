namespace WishListBot.API.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(Guid User) : base($"Пользователь: {User} не найден")
        {
        }
    }
}
