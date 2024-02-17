using FluentValidation;
using WishListBot.API.Presentation.Models;

namespace WishListBot.Presentation.Validators
{
    public class TelegramRequestValidator : AbstractValidator<TelegramRequest>
    {
        // Конструктор
        public TelegramRequestValidator()
        {
            // Правило для проверки наличия сообщения
            RuleFor(r => r.Message).NotNull().WithMessage("Message is required");

            // Правило для проверки наличия чата
            RuleFor(r => r.Message.Chat).NotNull().WithMessage("Chat is required");

            // Правило для проверки наличия идентификатора чата
            RuleFor(r => r.Message.Chat.Id).NotEqual(0).WithMessage("Chat id is required");

            // Правило для проверки наличия имени пользователя
            RuleFor(r => r.Message.Chat.FirstName).NotEmpty().WithMessage("User name is required");

            // Правило для проверки наличия текста сообщения
            RuleFor(r => r.Message.Text).NotEmpty().WithMessage("Message text is required");
        }
    }
}

