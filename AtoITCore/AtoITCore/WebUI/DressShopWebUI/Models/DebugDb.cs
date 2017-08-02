using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using Domain.Concrete;
using Domain.Entityes;
using static System.DateTime;

namespace DressShopWebUI.Models
{
    /// <summary>
    /// Добавление "фейковых" записей в БД, для работы с ними
    /// </summary>
    public class DebugDb
    {

        public static void TestDb()
        {
            ShopContext db = new ShopContext();
            DbSet<Photo> product = db.Photo;
            if (!product.Any()) // проверка на наличие БД и записей.
                AddToDb();// Если БД пустая - заполнит "тестовыми значениями"
        }
        public static void AddToDb()
        {
            var db = new ShopContext();

            #region Отзывы

            db.Reviews.Add(new Reviews
            {
                ClientName = "Вася Пупкин",
                ClientFeedback = "Супер платье, для рыбалки самое оно! Даже жене не отдал, сам ношу!",
                Email = "galina@gmail.com",
                Advantages = "Видя меня в этом платье - рыбаки место уступают!",
                Rating = 5,
                DateFeedback = Now
            });
            Thread.Sleep(10);//ставлю задержку для хоть небольшой разницы во времени создания отзывов, для сортировки

            db.Reviews.Add(new Reviews
            {
                ClientName = "Галя Марченко",
                ClientFeedback = "Ваааау!!! Вот это пошив! все нитки на второй день повылазили :)",
                Email = "galina@gmail.com",
                Advantages = "Повылазившими нитками заштопала мужу носки!",
                LackOf = "Гадкие нитки, даже из носков повылазили :( ",
                Rating = 3,
                DateFeedback = Now
            });
            Thread.Sleep(10);

            db.Reviews.Add(new Reviews
            {
                ClientName = "Ваня Гуцал",
                ClientFeedback = "Магазин что надо, все работает быстро и приятно, а главное не надо по базару с женой ходить!",
                Email = "gutsal@yandex.ru",
                Advantages = "Даже с дивана не встал!",
                Rating = 5,
                DateFeedback = Now
            });
            Thread.Sleep(10);

            db.Reviews.Add(new Reviews
            {
                ClientName = "Алена Лапкина",
                ClientFeedback = "Ми-Ми-Ми, как же я люблю подобные платья! они прекрасно подчеркивают мою творческую натуру!",
                Email = "alena.Lapkina@mail.ru",
                Advantages = "Красиво на тремпеле смотриться! :)",
                LackOf = "Только одела, и сразу натуру поплющило!!!",
                Rating = 1,
                DateFeedback = Now
            });
            Thread.Sleep(10);

            db.Reviews.Add(new Reviews
            {
                ClientName = "Дуняша Василенко",
                ClientFeedback = "Подскажите, а размеры для маленьких есть? я вот хочу у мамы выпросить новое платье, чтобы в школе все засохли от зависти!",
                Email = "galina@gmail.com",
                LackOf = "я в нем тоооолстая!!! :( ",
                Rating = 1,
                DateFeedback = Now
            });
            Thread.Sleep(10);
            


            #endregion

            #region Товар

            db.Product.Add(new Product
            {
                Name = "Офигеть не встать!",
                Description = "Сшито капроновыми нитками в подполье",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress1.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress1.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress1.jpg",Priority = false}
                    },
                Discount = 50,
                Category = "Selling",
                Price = 1200,
                SpecOffer = "Купи и леденец в подарок!",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "С будуна",
                Description = "Косо криво - абы живо!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress2.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress2.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress2.jpg",Priority = false}
                    },
                Category = "Selling",
                Discount = 10,
                Price = 500,
                SpecOffer = "Обучим пьяному стилю",
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "На глаз",
                Description = "а и правда - зачем выкройка?",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress3.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress3.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress3.jpg",Priority = false}
                    },
                Category = "Selling",
                Price = 4200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Очумелые ручки",
                Description = "Настолько очумели - что вот такое пошили!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress4.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress4.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress4.jpg",Priority = false}
                    },
                Discount = 30,
                Category = "Selling",
                Price = 200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Веселая леди",
                Description = "Оцените всю веселость этой леди!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress6.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress6.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress6.jpg",Priority = false}
                    },
                Category = "Selling",
                Price = 1200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Вырви глаз",
                Description = "Специальная психо-физичесская методика пошива, позволяет быстро улучшить ваше зрение!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress7.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress7.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress7.jpg",Priority = false}
                    },
                Discount = 20,
                Category = "Selling",
                Price = 8200,
                SpecOffer = "+ поход к окулисту!",
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Показуха",
                Description = "Это платье давно уже купили - но вот, посмотрите какая красотааа!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress8.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress8.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress8.jpg",Priority = false}
                    },
                Category = "Gallery",
                Price = 1200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Выставочно платьеце",
                Description = "Просто похвастаться",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress5.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress5.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress5.jpg",Priority = false}
                    },
                Category = "Gallery",
                Price = 1200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Мольба конкурента",
                Description = "произведенно соседкой по койке",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress9.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress9.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress9.jpg",Priority = false}
                    },
                Discount = 5,
                Category = "Partners",
                Price = 3300,
                SpecOffer = "Купи - обрадуй соседку!",
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Вокруг китай",
                Description = "Маде ин чина",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress10.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress10.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress10.jpg",Priority = false}
                    },
                Category = "Partners",
                Price = 100,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);
            db.Product.Add(new Product
            {
                Name = "Офигеть не встать!",
                Description = "Сшито капроновыми нитками в подполье",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress1.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress1.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress1.jpg",Priority = false}
                    },
                Discount = 50,
                Category = "Selling",
                Price = 1200,
                SpecOffer = "Купи и леденец в подарок!",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "С будуна",
                Description = "Косо криво - абы живо!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress2.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress2.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress2.jpg",Priority = false}
                    },
                Category = "Selling",
                Discount = 10,
                Price = 500,
                SpecOffer = "Обучим пьяному стилю",
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "На глаз",
                Description = "а и правда - зачем выкройка?",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress3.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress3.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress3.jpg",Priority = false}
                    },
                Category = "Selling",
                Price = 4200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Очумелые ручки",
                Description = "Настолько очумели - что вот такое пошили!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress4.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress4.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress4.jpg",Priority = false}
                    },
                Discount = 30,
                Category = "Selling",
                Price = 200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Веселая леди",
                Description = "Оцените всю веселость этой леди!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress6.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress6.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress6.jpg",Priority = false}
                    },
                Category = "Selling",
                Price = 1200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Вырви глаз",
                Description = "Специальная психо-физичесская методика пошива, позволяет быстро улучшить ваше зрение!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress7.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress7.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress7.jpg",Priority = false}
                    },
                Discount = 20,
                Category = "Selling",
                Price = 8200,
                SpecOffer = "+ поход к окулисту!",
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Показуха",
                Description = "Это платье давно уже купили - но вот, посмотрите какая красотааа!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress8.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress8.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress8.jpg",Priority = false}
                    },
                Category = "Gallery",
                Price = 1200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Выставочно платьеце",
                Description = "Просто похвастаться",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress5.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress5.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress5.jpg",Priority = false}
                    },
                Category = "Gallery",
                Price = 1200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Мольба конкурента",
                Description = "произведенно соседкой по койке",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress9.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress9.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress9.jpg",Priority = false}
                    },
                Discount = 5,
                Category = "Partners",
                Price = 3300,
                SpecOffer = "Купи - обрадуй соседку!",
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Вокруг китай",
                Description = "Маде ин чина",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress10.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress10.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress10.jpg",Priority = false}
                    },
                Category = "Partners",
                Price = 100,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);
            db.Product.Add(new Product
            {
                Name = "Офигеть не встать!",
                Description = "Сшито капроновыми нитками в подполье",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress1.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress1.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress1.jpg",Priority = false}
                    },
                Discount = 50,
                Category = "Selling",
                Price = 1200,
                SpecOffer = "Купи и леденец в подарок!",
                DateCreate = Now
            });
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "С будуна",
                Description = "Косо криво - абы живо!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress2.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress2.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress2.jpg",Priority = false}
                    },
                Category = "Selling",
                Discount = 10,
                Price = 500,
                SpecOffer = "Обучим пьяному стилю",
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "На глаз",
                Description = "а и правда - зачем выкройка?",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress3.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress3.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress3.jpg",Priority = false}
                    },
                Category = "Selling",
                Price = 4200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Очумелые ручки",
                Description = "Настолько очумели - что вот такое пошили!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress4.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress4.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress4.jpg",Priority = false}
                    },
                Discount = 30,
                Category = "Selling",
                Price = 200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Веселая леди",
                Description = "Оцените всю веселость этой леди!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress6.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress6.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress6.jpg",Priority = false}
                    },
                Category = "Selling",
                Price = 1200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Вырви глаз",
                Description = "Специальная психо-физичесская методика пошива, позволяет быстро улучшить ваше зрение!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress7.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress7.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress7.jpg",Priority = false}
                    },
                Discount = 20,
                Category = "Selling",
                Price = 8200,
                SpecOffer = "+ поход к окулисту!",
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Показуха",
                Description = "Это платье давно уже купили - но вот, посмотрите какая красотааа!",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress8.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress8.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress8.jpg",Priority = false}
                    },
                Category = "Gallery",
                Price = 1200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Выставочно платьеце",
                Description = "Просто похвастаться",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress5.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress5.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress5.jpg",Priority = false}
                    },
                Category = "Gallery",
                Price = 1200,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Мольба конкурента",
                Description = "произведенно соседкой по койке",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress9.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress9.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress9.jpg",Priority = false}
                    },
                Discount = 30,
                Category = "Partners",
                Price = 3300,
                SpecOffer = "Купи - обрадуй соседку!",
                DateCreate = Now
            }
           );
            Thread.Sleep(10);

            db.Product.Add(new Product
            {
                Name = "Вокруг китай",
                Description = "Маде ин чина",
                Photo = new List<Photo>
                    {
                        new Photo {PhotoUrl = "dress10.jpg",Priority = true},
                        new Photo {PhotoUrl = "dress10.jpg",Priority = false},
                        new Photo {PhotoUrl = "dress10.jpg",Priority = false}
                    },
                Category = "Partners",
                Price = 100,
                DateCreate = Now
            }
           );
            Thread.Sleep(10);


            #endregion

            db.SaveChanges();
        }

    }
}