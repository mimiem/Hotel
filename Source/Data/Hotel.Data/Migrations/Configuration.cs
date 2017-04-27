namespace Hotel.Data.Migrations
{
    using global::Hotel.Hotel.Data;
    using System.Data.Entity.Migrations;
    using System;
    using Models;
    using Models.Enumerations;
    using Common.HelperExtensions;
    using System.Collections.Generic;
     
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
            //SeedImages(context);

        }

        private void SeedImages(ApplicationDbContext context)
        {
            string path = @"C:\Users\User1\Documents\GitHub\Hotel\Source\Web\Hotel.Web\Content\Images\";

            List<Picture> pictures = new List<Picture>();

            for (int i = 1; i < 4; i++)
            {
                Picture newPicture = new Picture
                {
                    Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "0"),
                    Image = ImageConverter.ImageToByteArray(path + "room"+i+".jpg")
                };
                pictures.Add(newPicture);
            }

            for (int i = 1; i < 4; i++)
            {
                Picture newPicture = new Picture
                {
                    Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "1"),
                    Image = ImageConverter.ImageToByteArray(path + "restaurant" + i + ".jpg")
                };
                pictures.Add(newPicture);
            }

            for (int i = 1; i < 4; i++)
            {
                Picture newPicture = new Picture
                {
                    Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "3"),
                    Image = ImageConverter.ImageToByteArray(path + "hall" + i + ".jpg")
                };
                pictures.Add(newPicture);
            }

            for (int i = 1; i < 3; i++)
            {
                Picture newPicture = new Picture
                {
                    Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "2"),
                    Image = ImageConverter.ImageToByteArray(path + "piano-bar" + i + ".jpg")
                };
                pictures.Add(newPicture);
            }

            Picture picture = new Picture
            {
                Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "4"),
                Image = ImageConverter.ImageToByteArray(path + "hotel1.jpg")
            };
            pictures.Add(picture);

            pictures.ForEach(s => context.Pictures.AddOrUpdate(p => p.Id, s));
        }
    }
}
