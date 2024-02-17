using MediatR;
using WishListBot.API.ApplicationBLL.DTOs;

namespace WishListBot.API.ApplicationBLL.Commands
{
    /// <summary>
    /// Класс, который представляет команду добавления желания
    /// </summary>
    public class AddWishCommand : IRequest<WishDto>
    {
        // Свойство для хранения данных пользователя
        public UserDto User { get; }

        // Свойство для хранения названия желания
        public WishDto Wish { get; }

 
        // Конструктор с параметрами
        public AddWishCommand(UserDto user, WishDto wish)
        {
            User = user;
            Wish = wish;
        }
    }
}
