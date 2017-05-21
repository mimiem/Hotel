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
                Name = "Ресторанти",
                Description = "Основният ресторант с капацитет от 160 места предлага в приятна и непринудена атмосфера богата селекция от традиционна българска и разнообразна европейска кухня. " +
                "Нашето елегантно лоби е идеално място за среща с приятели или бизнес партньори,на чаша ароматно кафе, " +
                "марково питие или екзотичен коктейл.Разполагаме и с китайски ресторант \"Червеният дракон\"." +
                "Хотелът разполага и с бар - мецанин както и с бар - тераса за летните месеци." +
                "За най - малките гости на хотела предлагаме услугите на детска занималня с много играчки и забавни игри.",
                Facilities = "Ресторант – 160 места Лоби бар – 40 места|Пицария \"Верди\"|Детска занималня|Български специалитети|Европейска кухня",

                Pictures = context.Pictures.Where(p => p.Category == (ImageCategory)1).ToList()
            };

            context.Entertainments.AddOrUpdate(e1);

            Entertainment e2 = new Entertainment()
            {
                Name = "СПА център",
                Description = "Спа центърa е прекрасна възможност да се погрижите за здравето и добрата си форма в приятна атмосфера. Той разполага със закрит отопляем плувен басейн, " +
                "зала за релаксация, джакузи, сауна, солариум, стая с аромати, разнообразие от терапии и масажи. " +
                "Екстри: класически масаж, аромотерапия, лечебен масаж, антистресов масаж, маска и масаж на лице, антицелулитни процедури и др. " +
                "Любителите на спорта, могат да тренират в богато оборудваната фитнес зала и да използват услугите на професионален фитнес инструктор. " +
                "Поглезете се, позволете си подмладяване на тялото, ума и духа с ароматни масла, нежна музика и грижовни ръце.Наслада и спокойствие за сетивата ви. " +
                "Халати се дават на рецепция след поискване и депозит.",
                Facilities = "ПЛУВЕН БАСЕЙН|ФИТНЕС ЗАЛА|ДЖАКУЗИ|САУНА|СОЛАРИУМ|СТАЯ С АРОМАТИ|ЗАЛА ЗА РЕЛАКСАЦИЯ|МАСАЖ|АРОМОТЕРАПИЯ|АНТИЦЕЛУЛИТНИ ПРОЦЕДУРИ",
                Pictures = context.Pictures.Where(p => p.Category == (ImageCategory)5).ToList()
            };

            context.Entertainments.AddOrUpdate(e2);

            Entertainment e3 = new Entertainment()
            {
                Name = "Барове",
                Description = "Заповядайте в пиано-бара. Тук ще намерите подбрано разнообразие от алкохолни и безалкохолни питиета, коктейли, пури – за ценители! " +
                "Със силектирана музика, нашите музиканти и млад персонал, ще се погрижат за Вашето безупречно обслужване и добро настоение! ",
                Facilities = "Бар - мецанин|Бар - тераса|Коктейли|Класически напитки|Игрална на зала|Билярд|Електронни игри",
                Pictures = context.Pictures.Where(p => p.Category == (ImageCategory)2).ToList()
            };
            context.Entertainments.Add(e3);

            Entertainment e4 = new Entertainment()
            {
                Name = "Конферентни зали",
                Description = "Конферентният блок на хотел \"Blue River\" се състои от две зали, предлагащи перфектни условия за провеждане на семинари, делови срещи, конференции, " +
                "фирмено обучение и коктейли. Зала с 120 места и VIP-зала с 20 места, подходяща и за частни срещи. " +
                "На своите бизнес гости хотел \"Blue River\" предлага конферентни зали с най - съвременно оборудване, " +
                "възможности за мултимедийни презентации, " +
                "напълно професионално озвучаване с непрекъснато техническо присъствие и др.",
                Facilities = "ЗАЛА С 120 МЕСТА|VIP-ЗАЛА С 20 МЕСТА|ПРОФЕСИОНАЛНО ОЗВУЧАВАНЕ|МУЛТИМЕДИЙНИ ПРЕЗЕНТАЦИИ|ТЕХНИЧЕСКО ПРИСЪСТВИЕ|БЕЗЖИЧЕН ИНТЕРНЕТ",
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
                new RoomType() {Type="Двойна стая", Price = 55.0 },
                new RoomType() {Type="Двойна стая Deluxe", Price = 75.0 },
                new RoomType() {Type="Апартамент", Price = 90.0 },
                new RoomType() {Type="Апартамент фамилен", Price = 120.0 }
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
                Name = "Стаи",
                ShortDescription = "Изберете си стая или апартамент с невероятна гледка към планината, докато реката тихо ромоли на една ръка разстояние.",
                Picture = context.Pictures.First(p => p.Category == (ImageCategory)0)
            };

            context.Categories.Add(category1);

            CategoryPictures category2 = new CategoryPictures()
            {
                Name = "Ресторанти",
                ShortDescription = "Опитайте невероятно вкусни и изискани специалитети приготвени от едни от най-добрите готвачи в страната.",
                Picture = context.Pictures.First(p => p.Category == (ImageCategory)1)
            };

            context.Categories.Add(category2);

            CategoryPictures category3 = new CategoryPictures()
            {
                Name = "Конферентна база",
                ShortDescription = "От строго делови мероприятия през бляскави тържества до значими социални събития. Превърнете вашето събитие в истински успех!",
                Picture = context.Pictures.First(p => p.Category == (ImageCategory)3)
            };

            context.Categories.Add(category3);

            CategoryPictures category4 = new CategoryPictures()
            {
                Name = "Барове",
                ShortDescription = "...",
                Picture = context.Pictures.First(p => p.Category == (ImageCategory)2)
            };

            context.Categories.Add(category4);

            CategoryPictures category5 = new CategoryPictures()
            {
                Name = "СПА",
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
