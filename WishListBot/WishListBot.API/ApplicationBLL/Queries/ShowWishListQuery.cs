using MediatR;
using WishListBot.API.ApplicationBLL.DTOs;

namespace WishListBot.API.ApplicationBLL.Queries
{
    // Класс, который представляет запрос показа списка желаний текущего пользователя
    public class ShowWishListQuery : IRequest<List<WishDto>>
    {
        // Конструктор без параметров
        public ShowWishListQuery()
        {
        }
    }
}
