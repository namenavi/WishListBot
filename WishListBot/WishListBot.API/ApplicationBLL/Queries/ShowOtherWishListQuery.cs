using MediatR;
using WishListBot.API.ApplicationBLL.DTOs;

namespace WishListBot.API.ApplicationBLL.Queries
{
    // Класс, который представляет запрос показа списка желаний другого пользователя
    public class ShowOtherWishListQuery : IRequest<List<WishDto>>
    {
        // Свойство, которое хранит имя пользователя
        public string UserName { get; set; }

        // Конструктор, который принимает имя пользователя
        public ShowOtherWishListQuery(string userName)
        {
            // Проверяем, что имя пользователя не пустое
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым", nameof(userName));
            }

            // Присваиваем свойству значение параметра
            UserName = userName;
        }
    }
}
