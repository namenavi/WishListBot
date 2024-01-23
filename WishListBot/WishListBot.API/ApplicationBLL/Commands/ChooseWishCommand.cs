using MediatR;

namespace WishListBot.API.ApplicationBLL.Commands
{
    /// <summary>
    /// Класс, который представляет команду выбора желания другого пользователя для исполнения
    /// </summary>
    public class ChooseWishCommand : IRequest
    {
        /// <summary>
        /// Свойство, которое хранит имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Свойство, которое хранит номер желания
        /// </summary>
        public int WishNumber { get; set; }

        /// <summary>
        /// Конструктор, который принимает имя пользователя и номер желания
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="wishNumber"></param>
        /// <exception cref="ArgumentException"></exception>
        public ChooseWishCommand(string userName, int wishNumber)
        {
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым", nameof(userName));
            }

            if(wishNumber <= 0)
            {
                throw new ArgumentException("Номер желания должен быть положительным", nameof(wishNumber));
            }

            UserName = userName;
            WishNumber = wishNumber;
        }
    }
}
