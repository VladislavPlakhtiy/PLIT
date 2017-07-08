using System.Collections.Generic;
using System.Threading;
using Domain.Concrete;
using Domain.Entityes;
using static System.DateTime;

namespace DressShopWebUI.Models
{
    public class DebugDb
    {
        public static void AddToDb()
        {
            var db = new ShopContext();

            #region Отзывы

            db.Reviews.Add(new Reviews
            {
                ClientName = "Вася Пупкин",
                ClientFeedback = "Супер платье, для рыбалки самое оно! Даже жене не отдал, сам ношу!",
                Rating = 5,
                DateFeedback = Now
            });
            Thread.Sleep(10);//ставлю задержку для хоть небольшой разницы во времени создания отзывов, для сортировки

            db.Reviews.Add(new Reviews
            {
                ClientName = "Галя Марченко",
                ClientFeedback = "Ваааау!!! Вот это пошив! все нитки на второй день повылазили :)",
                Rating = 1,
                DateFeedback = Now
            });
            Thread.Sleep(10);

            db.Reviews.Add(new Reviews
            {
                ClientName = "Ваня Гуцал",
                ClientFeedback = "Магазин что надо, все работает быстро и приятно, а главное не надо по базару с женой ходить!",
                Rating = 5,
                DateFeedback = Now
            });
            Thread.Sleep(10);

            db.Reviews.Add(new Reviews
            {
                ClientName = "Алена Лапкина",
                ClientFeedback = "Ми-Ми-Ми, как же я люблю подобные платья! они прекрасно подчеркивают мою творческую натуру!",
                Rating = 1,
                DateFeedback = Now
            });
            Thread.Sleep(10);

            db.Reviews.Add(new Reviews
            {
                ClientName = "Дуняша Василенко",
                ClientFeedback = "Подскажите, а размеры для маленьких есть? я вот хочу у мамы выпросить новое платье, чтобы в школе все засохли от зависти!",
                Rating = 1,
                DateFeedback = Now
            });


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
                Category = 1,
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
                Category = 1,
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
                Category = 1,
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
                Category = 1,
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
                Category = 1,
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
                Category = 1,
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
                Category = 2,
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
                Category = 2,
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
                Category = 3,
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
                Category = 3,
                Price = 100,
                DateCreate = Now
            }
           );

            #endregion

            db.SaveChanges();
        }

    }
}