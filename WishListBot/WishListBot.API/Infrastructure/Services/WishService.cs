using WishListBot.API.ApplicationBLL.Commands;
using WishListBot.API.ApplicationBLL.DTOs;
using WishListBot.API.ApplicationBLL.Interfaces;
using WishListBot.API.ApplicationBLL.Queries;
using WishListBot.API.Domain.Entities;
using WishListBot.API.Domain.Exceptions;
using WishListBot.API.Domain.Interfaces;

namespace WishListBot.API.Infrastructure.Services
{
    // Класс, который реализует интерфейс IWishService
    public class WishService : IWishService
    {
        // Свойство для хранения единицы работы
        private readonly IUnitOfWork _unitOfWork;

        // Конструктор с параметром
        public WishService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddWishAsync(User user, Wish wish)
        {
            // Добавляем желание в репозиторий
            await _unitOfWork.WishRepository.AddAsync(wish);

            // Сохраняем изменения в базе данных
            await _unitOfWork.SaveAsync();

        }

        public Task ChooseWishAsync(User user, User otherUser, Wish wish)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWishAsync(User user, Wish wish)
        {
            throw new NotImplementedException();
        }

        public Task<List<WishDto>> GetOtherWishListAsync(User user, User otherUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<WishDto>> GetWishListAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task MoveWishToDoneAsync(User user, Wish wish)
        {
            throw new NotImplementedException();
        }
    }
}
