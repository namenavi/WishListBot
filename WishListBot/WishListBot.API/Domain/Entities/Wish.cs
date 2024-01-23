namespace WishListBot.API.Domain.Entities
{
    // Класс, который представляет сущность желания
    public class Wish
    {
        // Свойство, которое хранит идентификатор желания
        public int Id { get; set; }

        // Свойство, которое хранит название желания
        public string Name { get; set; }

        // Свойство, которое хранит статус желания
        public WishStatus Status { get; set; }

        // Свойство, которое хранит ссылку на пользователя, которому принадлежит желание
        public User Owner { get; set; }

        // Свойство, которое хранит ссылку на пользователя, который выбрал желание для исполнения
        public User Executor { get; set; }

        // Свойство, которое хранит дату выбора желания
        public DateTime? ChosenDate { get; set; }

        // Свойство, которое хранит дату исполнения желания
        public DateTime? DoneDate { get; set; }

        // Свойство, которое хранит оценку исполненного желания
        public int? Rating { get; set; }

        // Конструктор, который принимает название желания
        public Wish(string name)
        {
            // Присваиваем свойству Name значение параметра name
            Name = name;

            // Присваиваем свойству Status значение WishStatus.New
            Status = WishStatus.New;
        }

        // Метод, который проверяет, может ли желание быть выбрано для исполнения
        public bool CanBeChosen()
        {
            // Возвращаем результат сравнения свойства Status с WishStatus.New
            return Status == WishStatus.New;
        }

        // Метод, который проверяет, может ли желание быть перемещено в исполненное
        public bool CanBeMovedToDone()
        {
            // Возвращаем результат сравнения свойства Status с WishStatus.Chosen
            return Status == WishStatus.Chosen;
        }

        // Метод, который проверяет, может ли желание быть оценено
        public bool CanBeRated()
        {
            // Возвращаем результат сравнения свойства Status с WishStatus.Done
            return Status == WishStatus.Done;
        }

        // Метод, который проверяет, может ли желание быть назначено исполнителем
        public bool CanBeAssigned()
        {
            // Возвращаем результат сравнения свойства Status с WishStatus.New
            return Status == WishStatus.New;
        }

        // Метод, который проверяет, может ли желание быть отменено
        public bool CanBeCanceled()
        {
            // Возвращаем результат логического ИЛИ сравнения свойства Status с WishStatus.Chosen и WishStatus.Assigned
            return Status == WishStatus.Chosen || Status == WishStatus.Assigned;
        }
    }
}

