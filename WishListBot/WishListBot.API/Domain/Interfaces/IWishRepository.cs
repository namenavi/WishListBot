using WishListBot.API.Domain.Entities;

namespace WishListBot.API.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс, который определяет методы для работы с репозиторием желаний
    /// </summary>
    public interface IWishRepository
    {
        /// <summary>
        /// Метод, который асинхронно добавляет желание в репозиторий
        /// </summary>
        /// <param name="wish"></param>
        /// <returns></returns>
        Task AddAsync(Wish wish);

        /// <summary>
        /// Метод, который асинхронно удаляет желание из репозитория
        /// </summary>
        /// <param name="wish"></param>
        /// <returns></returns>
        Task DeleteAsync(Wish wish);

        /// <summary>
        /// Метод, который асинхронно обновляет желание в репозитории
        /// </summary>
        /// <param name="wish"></param>
        /// <returns></returns>
        Task UpdateAsync(Wish wish);

        /// <summary>
        /// Метод, который асинхронно получает желание по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Wish> GetByIdAsync(int id);

        /// <summary>
        /// Метод, который асинхронно получает список всех желаний
        /// </summary>
        /// <returns></returns>
        Task<List<Wish>> GetAllAsync();

        /// <summary>
        /// Метод, который асинхронно получает список желаний по статусу
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<List<Wish>> GetByStatusAsync(WishStatus status);

        /// <summary>
        /// Метод, который асинхронно получает список желаний по исполнителю
        /// </summary>
        /// <param name="executor"></param>
        /// <returns></returns>
        Task<List<Wish>> GetByExecutorAsync(User executor);

        /// <summary>
        /// Метод, который асинхронно получает список желаний по пользователю
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<List<Wish>> GetByUserAsync(User user);
    }
}
