using WishListBot.API.ApplicationBLL.Interfaces;
using WishListBot.API.Domain.Interfaces;

namespace WishListBot.API.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        // Свойство для хранения контекста данных
        private readonly ApplicationDbContext _context;

        // Свойство для хранения репозитория желаний
        private IWishRepository _wishRepository;

        // Свойство для хранения репозитория пользователей
        private IUserRepository _userRepository;

        // Конструктор с параметром
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения репозитория желаний
        public IWishRepository WishRepository
        {
            get
            {
                // Если репозиторий еще не создан, то создаем его
                if(_wishRepository == null)
                {
                    _wishRepository = new WishRepository(_context);
                }
                // Возвращаем репозиторий
                return _wishRepository;
            }
        }

        // Метод для получения репозитория пользователей
        public IUserRepository UserRepository
        {
            get
            {
                // Если репозиторий еще не создан, то создаем его
                if(_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                // Возвращаем репозиторий
                return _userRepository;
            }
        }

        // Метод для сохранения изменений в базе данных
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
