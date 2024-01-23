using MediatR;

namespace WishListBot.API.ApplicationBLL.Commands
{
    /// <summary>
    /// Класс, который представляет команду удаления желания
    /// </summary>
    public class DeleteWishCommand : IRequest
    {
        /// <summary>
        /// Свойство, которое хранит номер желания
        /// </summary>
        public int WishNumber { get; set; }

        /// <summary>
        /// Конструктор, который принимает номер желания
        /// </summary>
        /// <param name="wishNumber"></param>
        /// <exception cref="ArgumentException"></exception>
        public DeleteWishCommand(int wishNumber)
        {
            if(wishNumber <= 0)
            {
                throw new ArgumentException("Номер желания должен быть положительным", nameof(wishNumber));
            }

            WishNumber = wishNumber;
        }
    }
}
