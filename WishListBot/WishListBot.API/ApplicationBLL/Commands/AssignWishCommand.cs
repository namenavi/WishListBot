using MediatR;

namespace WishListBot.API.ApplicationBLL.Commands
{
    /// <summary>
    /// Класс, который представляет команду назначения исполнителя для своего желания
    /// </summary>
    public class AssignWishCommand : IRequest
    {
        /// <summary>
        /// Свойство, которое хранит номер желания
        /// </summary>
        public int WishNumber { get; set; }

        /// <summary>
        /// Свойство, которое хранит имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Конструктор, который принимает номер желания и имя пользователя
        /// </summary>
        /// <param name="wishNumber"></param>
        /// <param name="userName"></param>
        /// <exception cref="ArgumentException"></exception>
        public AssignWishCommand(int wishNumber, string userName)
        {
            if(wishNumber <= 0)
            {
                throw new ArgumentException("Номер желания должен быть положительным", nameof(wishNumber));
            }

            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым", nameof(userName));
            }

            WishNumber = wishNumber;
            UserName = userName;
        }
    }
}
