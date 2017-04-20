namespace Hotel.Data.Migrations
{
    using global::Hotel.Hotel.Data;
    using Models;
    using Models.Enumerations;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            //TODO Remove after
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //context.RoomsStatus.Add(new RoomStatus() { Status = (Status)Enum.Parse(typeof(Status), "1") });
            //context.RoomsStatus.Add(new RoomStatus() { Status = (Status)Enum.Parse(typeof(Status), "2") });

        }
    }
}
