using MediatR;

namespace WishListBot.API.ApplicationBLL.Commands
{
    /// <summary>
    /// Класс, который представляет команду добавления желания
    /// </summary>
    public class AddWishCommand : IRequest
    {
        /// <summary>
        /// Свойство, которое хранит название желания
        /// </summary>
        public string WishName { get; set; }

        /// <summary>
        /// Конструктор, который принимает название желания
        /// </summary>
        /// <param name="wishName"></param>
        /// <exception cref="ArgumentException"></exception>
        public AddWishCommand(string wishName)
        {
            if(string.IsNullOrEmpty(wishName))
            {
                throw new ArgumentException("Название желания не может быть пустым", nameof(wishName));
            }

            WishName = wishName;
        }
    }
}
