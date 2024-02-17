using Microsoft.EntityFrameworkCore;
using WishListBot.API.Domain.Entities;
/// <summary>
/// Класс, который представляет контекст базы данных
/// </summary>
public partial class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Свойство, которое хранит набор сущностей желаний
    /// </summary>
    public DbSet<Wish> Wishes { get; set; }

    /// <summary>
    /// Свойство, которое хранит набор сущностей пользователей
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Конструктор, который принимает опции контекста
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Метод для настройки модели данных
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка сущности желания
        modelBuilder.Entity<Wish>()
            .Property(w => w.Id)
            .ValueGeneratedOnAdd();// Указываем, что свойство Id генерируется базой данных
        modelBuilder.Entity<Wish>()
            .HasKey(w => w.Id); // Указание первичного ключа
        modelBuilder.Entity<Wish>()
            .Property(w => w.Name) // Указание свойства имени
            .IsRequired() // Обязательное поле
            .HasMaxLength(100); // Ограничение длины
        modelBuilder.Entity<Wish>()
            .Property(w => w.Description) // Указание свойства описания
            .HasMaxLength(500); // Ограничение длины
        modelBuilder.Entity<Wish>()
            .Property(w => w.Status) // Указание свойства статуса
            .IsRequired() // Обязательное поле
            .HasMaxLength(20); // Ограничение длины
        modelBuilder.Entity<Wish>()
            .HasOne(w => w.User) // Указание связи с пользователем
            .WithMany(u => u.Wishes) // Указание связи с коллекцией желаний
            .HasForeignKey(w => w.UserId) // Указание внешнего ключа
            .OnDelete(DeleteBehavior.Cascade); // Указание поведения при удалении
        modelBuilder.Entity<Wish>()
            .HasOne(w => w.Executor) // Указание связи с исполнителем
            .WithMany(u => u.ExecutableWishes) // Указание связи с коллекцией исполненных желаний
            .HasForeignKey(w => w.ExecutorId) // Указание внешнего ключа
            .OnDelete(DeleteBehavior.SetNull); // Указание поведения при удалении

        // Настройка сущности пользователя
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();// Указываем, что свойство Id генерируется базой данных
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id); // Указание первичного ключа
        modelBuilder.Entity<User>()
            .Property(u => u.Name) // Указание свойства имени
            .IsRequired() // Обязательное поле
            .HasMaxLength(50); // Ограничение длины
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Name) // Указание индекса по имени
           .IsUnique(); // Уникальное значение
        modelBuilder.Entity<User>()
           .Property(u => u.ChatId) // Указание свойства идентификатора чата
           .IsRequired(); // Обязательное поле
        modelBuilder.Entity<User>()
           .HasIndex(u => u.ChatId) // Указание индекса по идентификатору чата
           .IsUnique(); // Уникальное значение
    }


    ///// <summary>
    ///// Метод, который настраивает модели сущностей
    ///// </summary>
    ///// <param name="modelBuilder"></param>
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // Настраиваем сущность желания
    //    modelBuilder.Entity<Wish>(w =>
    //    {
    //        w.Property<int>("Id")
    //            .ValueGeneratedOnAdd();// Указываем, что свойство Id генерируется базой данных
    //        w.HasKey(w => w.Id);  // Указываем, что свойство Id является первичным ключом
    //        w.HasIndex(w => w.Id) 
    //            .IsUnique(); // Указываем, что свойство Name является уникальным индексом
    //    });

    //    modelBuilder.Entity<User>(u =>
    //    {
    //        u.Property<int>("Id")
    //            .ValueGeneratedOnAdd();
    //        u.HasKey(u => u.Id);
    //        u.HasIndex(u => u.Id)
    //            .IsUnique();
    //    });


    //    // Настраиваем отношение один-ко-многим между пользователем и желаниями
    //    modelBuilder.Entity<User>()
    //        // Указываем, что пользователь имеет много желаний
    //        .HasMany(u => u.Wishes)
    //        // Указываем, что желание имеет одного владельца
    //        .WithOne(w => w.Owner)
    //        // Указываем, что при удалении пользователя удаляются все его желания
    //        .OnDelete(DeleteBehavior.Cascade);

    //}
}

