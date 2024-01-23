using MediatR;

namespace WishListBot.API.ApplicationBLL.Commands
{
    /// <summary>
    /// Класс, который представляет команду оценки исполнения желания
    /// </summary>
    public class RateWishCommand : IRequest
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
        /// Свойство, которое хранит оценку от 1 до 5
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Конструктор, который принимает имя пользователя, номер желания и оценку
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="wishNumber"></param>
        /// <param name="rating"></param>
        /// <exception cref="ArgumentException"></exception>
        public RateWishCommand(string userName, int wishNumber, int rating)
        {
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым", nameof(userName));
            }

            if(wishNumber <= 0)
            {
                throw new ArgumentException("Номер желания должен быть положительным", nameof(wishNumber));
            }

            if(rating < 1 || rating > 5)
            {
                throw new ArgumentException("Оценка должна быть от 1 до 5", nameof(rating));
            }

            UserName = userName;
            WishNumber = wishNumber;
            Rating = rating;
        }
    }
}
