namespace WishListBot.API.Domain.Entities
{
    /// <summary>
    /// Перечисление, которое определяет возможные статусы желания
    /// </summary>
    public enum WishStatus
    {
        /// <summary>
        /// Статус, который означает, что желание новое
        /// </summary>
        New,

        /// <summary>
        /// Статус, который означает, что желание выбрано для исполнения
        /// </summary>
        Chosen,

        /// <summary>
        /// Статус, который означает, что желание исполнено
        /// </summary>
        Done

        ///// <summary>
        ///// Статус, который означает, что желание назначено исполнителем
        ///// </summary>
        //Assigned
    }

    /// <summary>
    /// Перечисление, которое определяет возможные статусы желания
    /// </summary>
    public enum StateUser
    {
        /// <summary>
        /// Статус, который означает, что желание новое
        /// </summary>
        AddWish,

        /// <summary>
        /// Статус, который означает, что желание выбрано для исполнения
        /// </summary>
        DeleteWish,

        /// <summary>
        /// Статус, который означает, что желание исполнено
        /// </summary>
        ShowWishList,
        ShowOtWishList,

    }
}

