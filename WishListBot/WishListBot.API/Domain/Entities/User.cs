namespace WishListBot.API.Domain.Entities
{
    // Класс, который представляет сущность пользователя
    public class User
    {
        // Свойство, которое хранит идентификатор пользователя
        public int Id { get; set; }

        // Свойство, которое хранит имя пользователя
        public string Name { get; set; }

        // Свойство, которое хранит список желаний пользователя
        public List<Wish> Wishes { get; set; }

        // Конструктор, который принимает имя пользователя
        public User(string name)
        {
            // Присваиваем свойству Name значение параметра name
            Name = name;

            // Инициализируем свойство Wishes пустым списком
            Wishes = new List<Wish>();
        }

        // Метод, который добавляет желание в список желаний пользователя
        public void AddWish(Wish wish)
        {
            // Присваиваем свойству Owner желания ссылку на текущего пользователя
            wish.Owner = this;

            // Добавляем желание в список Wishes
            Wishes.Add(wish);
        }

        // Метод, который удаляет желание из списка желаний пользователя
        public void DeleteWish(Wish wish)
        {
            // Удаляем желание из списка Wishes
            Wishes.Remove(wish);
        }

        // Метод, который перемещает желание в исполненное
        public void MoveWishToDone(Wish wish)
        {
            // Присваиваем свойству Status желания значение WishStatus.Done
            wish.Status = WishStatus.Done;

            // Присваиваем свойству DoneDate желания текущую дату
            wish.DoneDate = DateTime.Now;
        }

        // Метод, который выбирает желание другого пользователя для исполнения
        public void ChooseWish(User otherUser, Wish wish)
        {
            // Присваиваем свойству Status желания значение WishStatus.Chosen
            wish.Status = WishStatus.Chosen;

            // Присваиваем свойству Executor желания ссылку на текущего пользователя
            wish.Executor = this;

            // Присваиваем свойству ChosenDate желания текущую дату
            wish.ChosenDate = DateTime.Now;
        }

        // Метод, который оценивает исполненное желание
        public void RateWish(User otherUser, Wish wish, int rating)
        {
            // Присваиваем свойству Rating желания значение параметра rating
            wish.Rating = rating;
        }

        // Метод, который назначает исполнителя желания
        public void AssignWish(User otherUser, Wish wish)
        {
            // Присваиваем свойству Status желания значение WishStatus.Assigned
            wish.Status = WishStatus.Assigned;

            // Присваиваем свойству Executor желания ссылку на текущего пользователя
            wish.Executor = this;
        }

        // Метод, который отменяет выбор или назначение желания
        public void CancelWish(User otherUser, Wish wish)
        {
            // Присваиваем свойству Status желания значение WishStatus.New
            wish.Status = WishStatus.New;

            // Присваиваем свойству Executor желания null
            wish.Executor = null;

            // Присваиваем свойству ChosenDate желания null
            wish.ChosenDate = null;
        }
    }
}

