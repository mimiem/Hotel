namespace Hotel.Hotel.Data
{
    using global::Hotel.Data;
    using global::Hotel.Data.Common.Models;
    using global::Hotel.Data.Hotel.Data.Models;
    using global::Hotel.Data.Migrations;
    using global::Hotel.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public IDbSet<Picture> Pictures { get; set; }
        public IDbSet<CategoryPictures> Categories { get; set; }
        public IDbSet<Room> Rooms { get; set; }
        public IDbSet<Reservation> Reservations { get; set; }
        public IDbSet<RoomType> RoomTypes { get; set; }
        public IDbSet<Entertainment> Entertainments { get; set; }


        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        IDbSet<T> IApplicationDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //one-to-many 
        //    modelBuilder.Entity<Reservation>()
        //                .HasRequired<Room>(s => s.Room) // Student entity requires Standard 
        //                .WithMany(s => s.Reservations); // Standard entity includes many Students entities

        //}

    }
}
