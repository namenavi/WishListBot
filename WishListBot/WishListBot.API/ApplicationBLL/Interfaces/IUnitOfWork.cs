using WishListBot.API.Domain.Interfaces;

namespace WishListBot.API.ApplicationBLL.Interfaces
{
    // Интерфейс, который определяет метод для сохранения изменений в базе данных
    public interface IUnitOfWork
    {
        /// <summary>
        /// Свойство для получения репозитория желаний
        /// </summary>
        IWishRepository WishRepository { get; }
        /// <summary>
        /// Свойство для получения репозитория пользователей
        /// </summary>
        IUserRepository UserRepository { get; }
        /// <summary>
        /// Метод, который асинхронно сохраняет изменения в базе данных
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
