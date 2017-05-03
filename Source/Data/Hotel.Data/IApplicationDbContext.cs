namespace Hotel.Data
{
    using Data.Models;
    using Hotel.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext : IDisposable
    {
        IDbSet<Picture> Pictures { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Room> Rooms { get; set; }
        IDbSet<MeetingHall> MeetingHalls { get; set; }
        IDbSet<Reservation> Reservations { get; set; }
        IDbSet<Restaurant> Restaurants { get; set; }
        IDbSet<RoomType> RoomTypes { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }


        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
