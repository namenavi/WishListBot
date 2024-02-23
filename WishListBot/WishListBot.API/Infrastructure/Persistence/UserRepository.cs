using Microsoft.EntityFrameworkCore;
using WishListBot.API.Domain.Entities;
using WishListBot.API.Domain.Exceptions;
using WishListBot.API.Domain.Interfaces;

namespace WishListBot.API.Infrastructure.Persistence
{
    // Класс, который реализует интерфейс IUserRepository
    public class UserRepository : IUserRepository
    {
        // Свойство, которое хранит ссылку на контекст базы данных
        private readonly ApplicationDbContext _context;

        // Конструктор, который принимает ссылку на контекст базы данных
        public UserRepository(ApplicationDbContext context)
        {
            // Присваиваем свойству Context значение параметра context
            _context = context;
        }
        // Метод, который асинхронно добавляет пользователя в репозиторий
        public async Task AddUserAsync(User user)
        {
            // Добавляем пользователя в набор сущностей пользователей
            await _context.Users.AddAsync(user);
        }

        // Метод, который асинхронно удаляет пользователя из репозитория
        public async Task DeleteUserAsync(User user)
        {
            // Получаем пользователя из набора сущностей пользователей по идентификатору
            User userToDelete = await _context.Users.FindAsync(user.Id);

            // Если пользователь не найден
            if(userToDelete == null)
            {
                // Бросаем исключение, что пользователь не найден
                throw new UserNotFoundException(user.Id);
            }

            // Удаляем пользователя из набора сущностей пользователей
            _context.Users.Remove(userToDelete);
        }

        // Метод, который асинхронно обновляет пользователя в репозитории
        public async Task UpdateUserAsync(User user)
        {
            // Получаем пользователя из набора сущностей пользователей по идентификатору
            User userToUpdate = await _context.Users.FindAsync(user.Id);

            // Если пользователь не найден
            if(userToUpdate == null)
            {
                // Бросаем исключение, что пользователь не найден
                throw new UserNotFoundException(user.Id);
            }

            // Обновляем свойства пользователя
            userToUpdate.UserName = user.UserName;
            userToUpdate.Wishes = user.Wishes;
        }

        /// <summary>
        /// Метод, который асинхронно получает пользователя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            // Возвращаем пользователя из набора сущностей пользователей по идентификатору
            return await _context.Users.FindAsync(id);
        }

        // Метод, который асинхронно получает пользователя по имени
        public async Task<User> GetUserByNameAsync(string userName)
        {
            // Возвращаем пользователя из набора сущностей пользователей по имени
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
