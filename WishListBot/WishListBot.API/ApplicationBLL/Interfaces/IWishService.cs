using WishListBot.API.ApplicationBLL.DTOs;
using WishListBot.API.Domain.Entities;

namespace WishListBot.API.ApplicationBLL.Interfaces
{
    // Интерфейс, который определяет методы для работы с желаниями
    public interface IWishService
    {
        // Метод, который асинхронно добавляет желание в репозиторий желаний
        Task AddWishAsync(User user, Wish wish);

        // Метод, который асинхронно удаляет желание из репозитория желаний
        Task DeleteWishAsync(User user, Wish wish);

        // Метод, который асинхронно перемещает желание в исполненное
        Task MoveWishToDoneAsync(User user, Wish wish);

        // Метод, который асинхронно выбирает желание другого пользователя для исполнения
        Task ChooseWishAsync(User user, User otherUser, Wish wish);

        // Метод для получения списка желаний пользователя
        Task<List<WishDto>> GetWishListAsync(User user);

        // Метод для получения списка желаний другого пользователя
        Task<List<WishDto>> GetOtherWishListAsync(User user, User otherUser);


        //// Метод, который асинхронно оценивает исполненное желание
        //Task RateWishAsync(User user, User otherUser, Wish wish, int rating);

        //// Метод, который асинхронно назначает исполнителя желания
        //Task AssignWishAsync(User user, User otherUser, Wish wish);

        //// Метод, который асинхронно отменяет выбор или назначение желания
        //Task CancelWishAsync(User user, User otherUser, Wish wish);

        //// Метод, который асинхронно получает желание по номеру
        //Task<Wish> GetWishByNumberAsync(User user, int number);

        //// Метод, который асинхронно получает список желаний пользователя
        //Task<List<Wish>> GetWishesByUserAsync(User user);

        //// Метод, который асинхронно получает пользователя по имени
        //Task<User> GetUserByNameAsync(string name);
    }
}
