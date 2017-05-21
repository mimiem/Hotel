namespace Hotel.Data.Migrations
{
    using global::Hotel.Hotel.Data;
    using System.Data.Entity.Migrations;
    using System;
    using Models;
    using Models.Enumerations;
    using Common.HelperExtensions;
    using System.Collections.Generic;
    using System.Linq;
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
            //SeedCategories(context);
            //SeedRoomType(context);
            //SeedRooms(context);
            //SeedEntertainments(context);   
        }

        private void SeedEntertainments(ApplicationDbContext context)
        {
            Entertainment e1 = new Entertainment()
            {
                Name = "����������",
                Description = "��������� ��������� � ��������� �� 160 ����� �������� � ������� � ����������� ��������� ������ �������� �� ����������� ��������� � ������������ ���������� �����. " +
                "������ ��������� ���� � ������� ����� �� ����� � �������� ��� ������ ���������,�� ���� �������� ����, " +
                "������� ����� ��� ��������� �������.����������� � � �������� ��������� \"��������� ������\"." +
                "������� ��������� � � ��� - ������� ����� � � ��� - ������ �� ������� ������." +
                "�� ��� - ������� ����� �� ������ ���������� �������� �� ������ ��������� � ����� ������� � ������� ����.",
                Facilities = "��������� � 160 ����� ���� ��� � 40 �����|������� \"�����\"|������ ���������|��������� ������������|���������� �����",

                Pictures = context.Pictures.Where(p => p.Category == (ImageCategory)1).ToList()
            };

            context.Entertainments.AddOrUpdate(e1);

            Entertainment e2 = new Entertainment()
            {
                Name = "��� ������",
                Description = "��� ������a � ��������� ���������� �� �� ��������� �� �������� � ������� �� ����� � ������� ���������. ��� ��������� ��� ������ �������� ������ ������, " +
                "���� �� ����������, �������, �����, ��������, ���� � �������, ������������ �� ������� � ������. " +
                "������: ���������� �����, ������������, ������� �����, ����������� �����, ����� � ����� �� ����, ������������� ��������� � ��. " +
                "���������� �� ������, ����� �� �������� � ������ ������������ ������ ���� � �� ��������� �������� �� ������������� ������ ����������. " +
                "��������� ��, ��������� �� ������������ �� ������, ��� � ���� � �������� �����, ����� ������ � �������� ����.������� � ����������� �� �������� ��. " +
                "������ �� ����� �� �������� ���� ��������� � �������.",
                Facilities = "������ ������|������ ����|�������|�����|��������|���� � �������|���� �� ����������|�����|������������|������������� ���������",
                Pictures = context.Pictures.Where(p => p.Category == (ImageCategory)5).ToList()
            };

            context.Entertainments.AddOrUpdate(e2);

            Entertainment e3 = new Entertainment()
            {
                Name = "������",
                Description = "����������� � �����-����. ��� �� �������� �������� ������������ �� ��������� � ������������ �������, ��������, ���� � �� ��������! " +
                "��� ����������� ������, ������ ��������� � ���� ��������, �� �� �������� �� ������ ���������� ���������� � ����� ���������! ",
                Facilities = "��� - �������|��� - ������|��������|���������� �������|������� �� ����|������|���������� ����",
                Pictures = context.Pictures.Where(p => p.Category == (ImageCategory)2).ToList()
            };
            context.Entertainments.Add(e3);

            Entertainment e4 = new Entertainment()
            {
                Name = "����������� ����",
                Description = "������������� ���� �� ����� \"Blue River\" �� ������ �� ��� ����, ���������� ��������� ������� �� ���������� �� ��������, ������ �����, �����������, " +
                "������� �������� � ��������. ���� � 120 ����� � VIP-���� � 20 �����, ��������� � �� ������ �����. " +
                "�� ������ ������ ����� ����� \"Blue River\" �������� ����������� ���� � ��� - ���������� ����������, " +
                "����������� �� ������������ �����������, " +
                "������� ������������� ���������� � ������������ ���������� ���������� � ��.",
                Facilities = "���� � 120 �����|VIP-���� � 20 �����|������������� ����������|������������ �����������|���������� ����������|�������� ��������",
                Pictures = context.Pictures.Where(p => p.Category == (ImageCategory)3).ToList()
            };

            context.Entertainments.Add(e4);

            context.SaveChanges();
        }

        private void SeedRooms(ApplicationDbContext context)
        {
            IEnumerable<Room> rooms = new List<Room>()
            {
                new Room() {RoomNumber=1,RoomType=GetRoomType(5,context)},
                new Room() {RoomNumber=2,RoomType=GetRoomType(5,context)},
                new Room() {RoomNumber=3,RoomType=GetRoomType(5,context)},
                new Room() {RoomNumber=4,RoomType=GetRoomType(5,context)},
                new Room() {RoomNumber=5,RoomType=GetRoomType(5,context)},
                new Room() {RoomNumber=6,RoomType=GetRoomType(6,context)},
                new Room() {RoomNumber=7,RoomType=GetRoomType(6,context)},
                new Room() {RoomNumber=8,RoomType=GetRoomType(6,context)},
                new Room() {RoomNumber=9,RoomType=GetRoomType(6,context)},
                new Room() {RoomNumber=10,RoomType=GetRoomType(6,context)},
                new Room() {RoomNumber=11,RoomType=GetRoomType(7,context)},
                new Room() {RoomNumber=12,RoomType=GetRoomType(7,context)},
                new Room() {RoomNumber=13,RoomType=GetRoomType(7,context)},
                new Room() {RoomNumber=14,RoomType=GetRoomType(8,context)},
                new Room() {RoomNumber=15,RoomType=GetRoomType(8,context)}

            };

            foreach (var room in rooms)
            {
                context.Rooms.Add(room);
            }

            context.SaveChanges();

        }

        private RoomType GetRoomType(int typeId, ApplicationDbContext context)
        {
            return context.RoomTypes.First(t => t.Id == typeId);
        }

        private void SeedRoomType(ApplicationDbContext context)
        {
            IEnumerable<RoomType> types = new List<RoomType>()
            {
                new RoomType() {Type="������ ����", Price = 55.0 },
                new RoomType() {Type="������ ���� Deluxe", Price = 75.0 },
                new RoomType() {Type="����������", Price = 90.0 },
                new RoomType() {Type="���������� �������", Price = 120.0 }
            };

            foreach (var type in types)
            {
                context.RoomTypes.Add(type);
            }

            context.SaveChanges();
        }

        private void SeedCategories(ApplicationDbContext context)
        {
            CategoryPictures category1 = new CategoryPictures()
            {
                Name = "����",
                ShortDescription = "�������� �� ���� ��� ���������� � ���������� ������ ��� ���������, ������ ������ ���� ������ �� ���� ���� ����������.",
                Picture = context.Pictures.First(p => p.Category == (ImageCategory)0)
            };

            context.Categories.Add(category1);

            CategoryPictures category2 = new CategoryPictures()
            {
                Name = "����������",
                ShortDescription = "�������� ���������� ������ � �������� ������������ ���������� �� ���� �� ���-������� ������� � ��������.",
                Picture = context.Pictures.First(p => p.Category == (ImageCategory)1)
            };

            context.Categories.Add(category2);

            CategoryPictures category3 = new CategoryPictures()
            {
                Name = "����������� ����",
                ShortDescription = "�� ������ ������ ����������� ���� �������� ��������� �� ������� �������� �������. ���������� ������ ������� � �������� �����!",
                Picture = context.Pictures.First(p => p.Category == (ImageCategory)3)
            };

            context.Categories.Add(category3);

            CategoryPictures category4 = new CategoryPictures()
            {
                Name = "������",
                ShortDescription = "...",
                Picture = context.Pictures.First(p => p.Category == (ImageCategory)2)
            };

            context.Categories.Add(category4);

            CategoryPictures category5 = new CategoryPictures()
            {
                Name = "���",
                ShortDescription = "...",
                Picture = context.Pictures.First(p => p.Category == (ImageCategory)5)
            };

            context.Categories.Add(category5);

            context.SaveChanges();
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
                    Image = ImageConverter.ImageToByteArray(path + "room" + i + ".jpg"),
                    Name = "room" + i
                };
                pictures.Add(newPicture);
            }

            for (int i = 1; i < 4; i++)
            {
                Picture newPicture = new Picture
                {
                    Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "1"),
                    Image = ImageConverter.ImageToByteArray(path + "restaurant" + i + ".jpg"),
                    Name = "restaurant" + i
                };
                pictures.Add(newPicture);
            }

            for (int i = 1; i < 4; i++)
            {
                Picture newPicture = new Picture
                {
                    Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "3"),
                    Image = ImageConverter.ImageToByteArray(path + "hall" + i + ".jpg"),
                    Name = "hall" + i
                };
                pictures.Add(newPicture);
            }

            for (int i = 1; i < 3; i++)
            {
                Picture newPicture = new Picture
                {
                    Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "2"),
                    Image = ImageConverter.ImageToByteArray(path + "piano-bar" + i + ".jpg"),
                    Name = "bar" + i
                };
                pictures.Add(newPicture);
            }

            Picture hotelPicture1 = new Picture
            {
                Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "4"),
                Image = ImageConverter.ImageToByteArray(path + "hotel1.jpg"),
                Name = "hotel1"
            };
            pictures.Add(hotelPicture1);

            Picture hotelPicture2 = new Picture
            {
                Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "4"),
                Image = ImageConverter.ImageToByteArray(path + "hotel2.jpg"),
                Name = "hotel2"
            };
            pictures.Add(hotelPicture2);

            Picture reception = new Picture
            {
                Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "4"),
                Image = ImageConverter.ImageToByteArray(path + "reception.jpg"),
                Name = "reception"
            };
            pictures.Add(reception);

            for (int i = 1; i < 8; i++)
            {
                Picture newPicture = new Picture
                {
                    Category = (ImageCategory)Enum.Parse(typeof(ImageCategory), "5"),
                    Image = ImageConverter.ImageToByteArray(path + "spa" + i + ".jpg"),
                    Name = "spa" + i
                };
                pictures.Add(newPicture);
            }

            pictures.ForEach(s => context.Pictures.AddOrUpdate(p => p.Id, s));
        }
    }
}
