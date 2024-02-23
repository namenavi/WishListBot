using MediatR;
using WishListBot.API.ApplicationBLL.Commands;
using WishListBot.API.ApplicationBLL.DTOs;
using WishListBot.API.ApplicationBLL.Interfaces;
using WishListBot.API.Domain.Entities;
using WishListBot.API.Domain.Exceptions;

namespace WishListBot.API.ApplicationBLL.Handlers
{
    /// <summary>
    /// Класс, который реализует интерфейс IRequestHandler для обработки команды добавления желания
    /// </summary>
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
            //// Получаем данные из запроса
            //var userName = request.User;
            //var wish = request.Wish;

            //// Добавляем новое желание с помощью сервиса
            //var wishDto = await _wishService.AddWishAsync(userName, wish);

            //// Возвращаем DTO
            //return wishDto;
            throw new NotImplementedException();
        }
    }
}
