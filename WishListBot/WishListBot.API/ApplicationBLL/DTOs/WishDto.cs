namespace WishListBot.API.ApplicationBLL.DTOs
{
    // Класс, который представляет объект передачи данных для желания
    public class WishDto
    {

        // Свойство для хранения идентификатора желания
        public int Id { get; set; }

        // Свойство для хранения названия желания
        public string Name { get; set; }

        // Свойство для хранения описания желания
        public string Description { get; set; }

        // Свойство для хранения статуса желания
        public string Status { get; set; }

        // Свойство для хранения имени владельца желания
        public string Owner { get; set; }

        // Свойство для хранения имени исполнителя желания
        public string Executor { get; set; }

        //// Свойство, которое хранит номер желания
        //public int Number { get; set; }

        //// Свойство, которое хранит название желания
        //public string Name { get; set; }

        //// Свойство, которое хранит статус желания
        //public string Status { get; set; }

        //// Свойство, которое хранит имя исполнителя желания
        //public string ExecutorName { get; set; }

        //// Свойство, которое хранит дату выбора желания
        //public DateTime? ChosenDate { get; set; }

        //// Свойство, которое хранит дату исполнения желания
        //public DateTime? DoneDate { get; set; }

        //// Свойство, которое хранит оценку исполненного желания
        //public int? Rating { get; set; }
    }
}
