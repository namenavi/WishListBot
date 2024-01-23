using WishListBot.API.Domain.Entities;

namespace WishListBot.API.Domain.Interfaces
{
    /// <summary>
    /// IUserRepository.cs - интерфейс, который определяет методы для работы с пользователями в базе данных.
    /// </summary>
    public interface IUserRepository
    {
        // Метод для получения пользователя по имени
        Task<User> GetUserByNameAsync(string userName);

        // Метод для добавления нового пользователя
        Task AddUserAsync(User user);

        // Метод для обновления существующего пользователя
        Task UpdateUserAsync(User user);

        // Метод для удаления пользователя по имени
        Task DeleteUserAsync(string userName);
    }
}
