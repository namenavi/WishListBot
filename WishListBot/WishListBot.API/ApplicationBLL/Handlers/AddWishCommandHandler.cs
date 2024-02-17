using MediatR;
using WishListBot.API.ApplicationBLL.Commands;
using WishListBot.API.ApplicationBLL.DTOs;
using WishListBot.API.ApplicationBLL.Interfaces;
using WishListBot.API.Domain.Entities;
using WishListBot.API.Domain.Exceptions;

namespace WishListBot.API.ApplicationBLL.Handlers
{
    //// Класс, который реализует интерфейс IRequestHandler для обработки команды добавления желания
    //public class AddWishCommandHandler : IRequestHandler<AddWishCommand>
    //{
    //    // Свойство, которое хранит ссылку на сервис телеграма
    //    private readonly ITelegramService _telegramService;

    //    // Свойство, которое хранит ссылку на сервис желаний
    //    private readonly IWishService _wishService;

    //    // Свойство, которое хранит ссылку на единицу работы
    //    private readonly IUnitOfWork _unitOfWork;

    //    // Конструктор, который принимает ссылки на сервисы и единицу работы
    //    public AddWishCommandHandler(ITelegramService telegramService, IWishService wishService, IUnitOfWork unitOfWork)
    //    {
    //        // Присваиваем свойствам значения параметров
    //        _telegramService = telegramService;
    //        _wishService = wishService;
    //        _unitOfWork = unitOfWork;
    //    }
        public class AddWishCommandHandler : IRequestHandler<AddWishCommand, WishDto>
        {
            // Свойство для хранения сервиса работы с желаниями
            private readonly IWishService _wishService;

            // Конструктор с параметром
            public AddWishCommandHandler(IWishService wishService)
            {
                _wishService = wishService;
            }

            // Метод для обработки команды
            public async Task<WishDto> Handle(AddWishCommand request, CancellationToken cancellationToken)
            {
                // Получаем данные из запроса
                var userName = request.User;
                var wish = request.Wish;

                // Добавляем новое желание с помощью сервиса
                var wishDto = await _wishService.AddWishAsync(userName, wish);

                // Возвращаем DTO
                return wishDto;
            }
        }

        //// Метод, который асинхронно обрабатывает команду добавления желания
        //public async Task<Unit> Handle(AddWishCommand request, CancellationToken cancellationToken)
        //{
        //    // Получаем текущего пользователя из сервиса телеграма
        //    User user = await _telegramService.GetCurrentUserAsync();

        //    // Создаем новый объект желания с названием из команды
        //    Wish wish = new Wish(request.WishName);

        //    // Пытаемся добавить желание в репозиторий желаний
        //    try
        //    {
        //        await _wishService.AddWishAsync(user, wish);
        //    }
        //    // Если возникло исключение, что желание уже существует
        //    catch(WishAlreadyExistsException ex)
        //    {
        //        // Отправляем пользователю сообщение об ошибке
        //        await _telegramService.SendMessageAsync(ex.Message);

        //        // Возвращаем пустую единицу
        //        return Unit.Value;
        //    }

        //    // Сохраняем изменения в базе данных
        //    await _unitOfWork.SaveAsync();

        //    // Отправляем пользователю сообщение об успешном добавлении желания
        //    await _telegramService.SendMessageAsync($"Желание \"{wish.Name}\" добавлено в ваш список");

        //    // Возвращаем пустую единицу
        //    return Unit.Value;
        //}

        //async Task IRequestHandler<AddWishCommand>.Handle(AddWishCommand request, CancellationToken cancellationToken)
        //{
        //    // Получаем текущего пользователя из сервиса телеграма
        //    User user = await _telegramService.GetCurrentUserAsync();

        //    // Создаем новый объект желания с названием из команды
        //    Wish wish = new Wish(request.WishName);

        //    // Пытаемся добавить желание в репозиторий желаний
        //    try
        //    {
        //        await _wishService.AddWishAsync(user, wish);
        //    }
        //    // Если возникло исключение, что желание уже существует
        //    catch(WishAlreadyExistsException ex)
        //    {
        //        // Отправляем пользователю сообщение об ошибке
        //        await _telegramService.SendMessageAsync(ex.Message);
        //    }

        //    // Сохраняем изменения в базе данных
        //    await _unitOfWork.SaveAsync();

        //    // Отправляем пользователю сообщение об успешном добавлении желания
        //    await _telegramService.SendMessageAsync($"Желание \"{wish.Name}\" добавлено в ваш список");
        //}
    //}
}
