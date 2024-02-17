using Microsoft.EntityFrameworkCore;
using WishListBot.API.Domain.Entities;
using WishListBot.API.Domain.Exceptions;
using WishListBot.API.Domain.Interfaces;

namespace WishListBot.API.Infrastructure.Persistence
{
    /// <summary>
    /// Класс, который реализует интерфейс IWishRepository
    /// </summary>
    public class WishRepository : IWishRepository
    {
        /// <summary>
        /// Свойство, которое хранит ссылку на контекст базы данных
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Конструктор, который принимает ссылку на контекст базы данных
        /// </summary>
        /// <param name="context"></param>
        public WishRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод, который асинхронно добавляет желание в репозиторий
        /// </summary>
        /// <param name="wish"></param>
        /// <returns></returns>
        public async Task AddAsync(Wish wish)
        {
            // Добавляем желание в набор сущностей желаний
            await _context.Wishes.AddAsync(wish);
        }

        /// <summary>
        /// Метод, который асинхронно удаляет желание из репозитория
        /// </summary>
        /// <param name="wish"></param>
        /// <returns></returns>
        /// <exception cref="WishNotFoundException"></exception>
        public async Task DeleteAsync(Wish wish)
        {
            // Получаем желание из набора сущностей желаний по идентификатору
            Wish wishToDelete = await _context.Wishes.FindAsync(wish.Id);

            // Если желание не найдено
            if(wishToDelete == null)
            {
                // Бросаем исключение, что желание не найдено
                throw new WishNotFoundException(wish.Id);
            }

            // Удаляем желание из набора сущностей желаний
            _context.Wishes.Remove(wishToDelete);
        }

        /// <summary>
        /// Метод, который асинхронно обновляет желание в репозитории
        /// </summary>
        /// <param name="wish"></param>
        /// <returns></returns>
        /// <exception cref="WishNotFoundException"></exception>
        public async Task UpdateAsync(Wish wish)
        {
            // Получаем желание из набора сущностей желаний по идентификатору
            Wish wishToUpdate = await _context.Wishes.FindAsync(wish.Id);

            // Если желание не найдено
            if(wishToUpdate == null)
            {
                // Бросаем исключение, что желание не найдено
                throw new WishNotFoundException(wish.Id);
            }

            // Обновляем свойства желания
            wishToUpdate.Name = wish.Name;
            wishToUpdate.Status = wish.Status;
            wishToUpdate.Owner = wish.Owner;
            wishToUpdate.Executor = wish.Executor;
            wishToUpdate.ChosenDate = wish.ChosenDate;
            wishToUpdate.DoneDate = wish.DoneDate;
            wishToUpdate.Rating = wish.Rating;
        }

        /// <summary>
        /// Метод, который асинхронно получает желание по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Wish> GetByIdAsync(int id)
        {
            // Возвращаем желание из набора сущностей желаний по идентификатору
            return await _context.Wishes.FindAsync(id);
        }

        /// <summary>
        /// Метод, который асинхронно получает список желаний по пользователю
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<Wish>> GetByUserAsync(User user)
        {
            // Возвращаем список желаний из набора сущностей желаний, отфильтрованный по пользователю
            return await _context.Wishes.Where(w => w.Owner == user).ToListAsync();
        }

        /// <summary>
        /// Метод, который асинхронно получает список всех желаний
        /// </summary>
        /// <returns></returns>
        public async Task<List<Wish>> GetAllAsync()
        {
            // Возвращаем список всех желаний из набора сущностей желаний
            return await _context.Wishes.ToListAsync();
        }

        /// <summary>
        /// Метод, который асинхронно получает список желаний по статусу
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<List<Wish>> GetByStatusAsync(WishStatus status)
        {
            // Возвращаем список желаний из набора сущностей желаний, отфильтрованный по статусу
            return await _context.Wishes.Where(w => w.Status == status).ToListAsync();
        }

        /// <summary>
        /// Метод, который асинхронно получает список желаний по исполнителю
        /// </summary>
        /// <param name="executor"></param>
        /// <returns></returns>
        public async Task<List<Wish>> GetByExecutorAsync(User executor)
        {
            // Возвращаем список желаний из набора сущностей желаний, отфильтрованный по исполнителю
            return await _context.Wishes.Where(w => w.Executor == executor).ToListAsync();
        }
    }
}

