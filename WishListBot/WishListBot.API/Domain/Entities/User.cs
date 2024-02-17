namespace WishListBot.API.Domain.Entities
{
    /// <summary>
    /// Класс, который представляет сущность пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Свойство, которое хранит идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Свойство, которое хранит имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство, которое хранит список желаний пользователя
        /// </summary>
        public ICollection<Wish>? Wishes { get; set; }
        /// <summary>
        /// Свойство, которое хранит список желаний для исполнения
        /// </summary>
        public ICollection<Wish>? ExecutableWishes { get; set; }
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public int ChatId { get; set; }

        /// <summary>
        /// Конструктор, который принимает имя пользователя
        /// </summary>
        /// <param name="name"></param>
        public User(string name)
        {
            Name = name;
            Wishes = new List<Wish>();
            ExecutableWishes = new List<Wish>();
        }

        /// <summary>
        /// Метод, который добавляет желание в список желаний пользователя
        /// </summary>
        /// <param name="wish"></param>
        public void AddWish(Wish wish)
        {
            /// Присваиваем свойству Owner желания ссылку на текущего пользователя
            wish.User = this;
            Wishes!.Add(wish);
        }

        /// <summary>
        /// Метод, который удаляет желание из списка желаний пользователя
        /// </summary>
        /// <param name="wish"></param>
        public bool DeleteWish(Wish wish)
        {
           return Wishes!.Remove(wish);
        }

        /// <summary>
        /// Метод, который перемещает желание в исполненное
        /// </summary>
        /// <param name="wish"></param>
        public void MoveWishToDone(Wish wish)
        {
            wish.Status = WishStatus.Done;
            wish.DoneDate = DateTime.Now;
        }

        /// <summary>
        /// Метод, который выбирает желание другого пользователя для исполнения
        /// </summary>
        /// <param name="otherUser"></param>
        /// <param name="wish"></param>
        public void ChooseWish(Wish wish)
        {
            wish.Status = WishStatus.Chosen;
            wish.Executor = this;
            wish.ChosenDate = DateTime.Now;
        }

        /// <summary>
        /// Метод, который оценивает исполненное желание
        /// </summary>
        /// <param name="otherUser"></param>
        /// <param name="wish"></param>
        /// <param name="rating"></param>
        public void RateWish(Wish wish, int rating)
        {
            wish.Rating = rating;
        }

        ///// <summary>
        ///// Метод, который назначает исполнителя желания
        ///// </summary>
        ///// <param name="otherUser"></param>
        ///// <param name="wish"></param>
        //public void AssignWish(Wish wish)
        //{
        //    wish.Status = WishStatus.Assigned;
        //    wish.Executor = this;
        //}

        /// <summary>
        /// Метод, который отменяет выбор или назначение желания
        /// </summary>
        /// <param name="otherUser"></param>
        /// <param name="wish"></param>
        public void CancelWish(Wish wish)
        {
            wish.Status = WishStatus.New;
            wish.Executor = null;
            wish.ChosenDate = null;
        }
    }
}

