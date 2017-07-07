using System.Collections.Generic;
using System.Threading;
using Domain.Entityes;
using static System.DateTime;

namespace DressShopWebUI.Models
{
    public class DebugDb
    {
        public static void AddToDb()
        {
            //добавление новых сущьностей в базу
            using (var db = new ShopContainer())
            {
                //создаем переменные сущьностей

       #region Сущьности



                
                //создание новых продуктов (10)
                var product1 = db.Product.Create();
                var product2 = db.Product.Create();
                var product3 = db.Product.Create();
                var product4 = db.Product.Create();
                var product5 = db.Product.Create();
                var product6 = db.Product.Create();
                var product7 = db.Product.Create();
                var product8 = db.Product.Create();
                var product9 = db.Product.Create();
                var product10 = db.Product.Create();
                //новые фото (30)
                var photo1 = db.Photo.Create();
                var photo2 = db.Photo.Create();
                var photo3 = db.Photo.Create();
                var photo4 = db.Photo.Create();
                var photo5 = db.Photo.Create();
                var photo6 = db.Photo.Create();
                var photo7 = db.Photo.Create();
                var photo8 = db.Photo.Create();
                var photo9 = db.Photo.Create();
                var photo10 = db.Photo.Create();
                var photo11 = db.Photo.Create();
                var photo12 = db.Photo.Create();
                var photo13 = db.Photo.Create();
                var photo14 = db.Photo.Create();
                var photo15 = db.Photo.Create();
                var photo16 = db.Photo.Create();
                var photo17 = db.Photo.Create();
                var photo18 = db.Photo.Create();
                var photo19 = db.Photo.Create();
                var photo20 = db.Photo.Create();
                var photo21 = db.Photo.Create();
                var photo22= db.Photo.Create();
                var photo23= db.Photo.Create();
                var photo24 = db.Photo.Create();
                var photo25= db.Photo.Create();
                var photo26 = db.Photo.Create();
                var photo27 = db.Photo.Create();
                var photo28 = db.Photo.Create();
                var photo29 = db.Photo.Create();
                var photo30 = db.Photo.Create();
                //категории (3)
                var sale = db.Category.Create();
                var gallery = db.Category.Create();
                var partners = db.Category.Create();
                //заказы (3) - но в магазине платьев не будет такой базы, просто пока потестить. 
                //Будем использовать сущьность как форму отправки заказа на мыло
                var orders1 = db.Orders.Create();
                var orders2 = db.Orders.Create();
                var orders3 = db.Orders.Create();
                //способы доставки (3)
                var ukrMail = db.Delivery.Create();
                var newMail = db.Delivery.Create();
                var selfCatering = db.Delivery.Create();
                //статус заказа (3)
                var newOrder = db.Status.Create();
                var inProcessing = db.Status.Create();
                var ready = db.Status.Create();
                //отзывы (5)
                var reviews1 = db.Reviews.Create();
                var reviews2 = db.Reviews.Create();
                var reviews3 = db.Reviews.Create();
                var reviews4 = db.Reviews.Create();
                var reviews5 = db.Reviews.Create();
          #endregion
                // заполнение полей сущьностей
                

                //создаем статусы заказов
                newOrder.StatusName = "новый";
                inProcessing.StatusName = "в обработке";
                ready.StatusName = "оформлен";

                //создаем способы доставки товара
                ukrMail.NameDelivery = "Укрпочта";
                newMail.NameDelivery = "Новая Почта";
                selfCatering.NameDelivery = "Самовывоз";

                // Создаем категории
                sale.NameCategory = "продажа";
                sale.Product.Add(product1);
                sale.Product.Add(product2);
                sale.Product.Add(product3);
                sale.Product.Add(product4);
                sale.Product.Add(product8);
                
                gallery.NameCategory = "галерея";
                gallery.Product.Add(product5);
                gallery.Product.Add(product6);
                gallery.Product.Add(product7);
                
                partners.NameCategory = "партнеры";
                partners.Product.Add(product9);
                partners.Product.Add(product10);

                //формируем отзывы
                #region создаем несколько отзывов
                
                reviews1.ClientName = "Вася Пупкин";
                reviews1.ClientFeedback = "Супер платье, для рыбалки самое оно! Даже жене не отдал, сам ношу!";
                reviews1.Rating = 5;
                reviews1.DateFeedback = Now;
                Thread.Sleep(10); //ставлю задержку для хоть небольшой разницы во времени создания отзывов, для сортировки
                
                reviews2.ClientName = "Галя Марченко";
                reviews2.ClientFeedback = "Ваааау!!! Вот это пошив! все нитки на второй день повылазили :)";
                reviews2.Rating = 1;
                reviews2.DateFeedback = Now;
                Thread.Sleep(10);
                
                reviews3.ClientName = "Ваня Гуцал";
                reviews3.ClientFeedback = "Магазин что надо, все работает быстро и приятно, а главное не надо по базару с женой ходить!";
                reviews3.Rating = 5;
                reviews3.DateFeedback = Now;
                Thread.Sleep(10);
                
                reviews4.ClientName = "Алена Лапкина";
                reviews4.ClientFeedback = "Ми-Ми-Ми, как же я люблю подобные платья! они прекрасно подчеркивают мою творческую натуру!";
                reviews4.Rating = 4;
                reviews4.DateFeedback = Now;
                Thread.Sleep(10);
                
                reviews5.ClientName = "Дуняша Василенко";
                reviews5.ClientFeedback = "Подскажите, а размеры для маленьких есть? я вот хочу у мамы выпросить новое платье, чтобы в школе все засохли от зависти!";
                reviews5.Rating = 5;
                reviews5.DateFeedback = Now;
                Thread.Sleep(10);
                #endregion
                //формируем фотки
        #region создаем фотки
                
                photo1.PhotoUrl = "~/Images/dress1.jpg";
                photo1.Priority = true;  //приоритет в показе на слайдере или в показе на главной
                photo2.PhotoUrl = "~/Images/dress1.jpg";
                photo2.Priority = false;
                photo3.PhotoUrl = "~/Images/dress1.jpg";
                photo3.Priority = false;
                photo4.PhotoUrl = "~/Images/dress2.jpg";
                photo4.Priority = true;
                photo5.PhotoUrl = "~/Images/dress2.jpg";
                photo5.Priority = false;
                photo6.PhotoUrl = "~/Images/dress2.jpg";
                photo6.Priority = false;
                photo7.PhotoUrl = "~/Images/dress3.jpg";
                photo7.Priority = true;
                photo8.PhotoUrl = "~/Images/dress3.jpg";
                photo8.Priority = false;
                photo9.PhotoUrl = "~/Images/dress3.jpg";
                photo9.Priority = false;
                photo10.PhotoUrl = "~/Images/dress4.jpg";
                photo10.Priority = true;
                photo11.PhotoUrl = "~/Images/dress4.jpg";
                photo11.Priority = false;
                photo12.PhotoUrl = "~/Images/dress4.jpg";
                photo12.Priority = false;
                photo13.PhotoUrl = "~/Images/dress5.jpg";
                photo13.Priority = true;
                photo14.PhotoUrl = "~/Images/dress5.jpg";
                photo14.Priority = false;
                photo15.PhotoUrl = "~/Images/dress5.jpg";
                photo15.Priority = false;
                photo16.PhotoUrl = "~/Images/dress6.jpg";
                photo16.Priority = true;
                photo17.PhotoUrl = "~/Images/dress6.jpg";
                photo17.Priority = false;
                photo18.PhotoUrl = "~/Images/dress6.jpg";
                photo18.Priority = false;
                photo19.PhotoUrl = "~/Images/dress7.jpg";
                photo19.Priority = true;
                photo20.PhotoUrl = "~/Images/dress7.jpg";
                photo20.Priority = false;
                photo21.PhotoUrl = "~/Images/dress7.jpg";
                photo21.Priority = false;
                photo22.PhotoUrl = "~/Images/dress8.jpg";
                photo22.Priority = true;
                photo23.PhotoUrl = "~/Images/dress8.jpg";
                photo23.Priority = false;
                photo24.PhotoUrl = "~/Images/dress8.jpg";
                photo24.Priority = false;
                photo25.PhotoUrl = "~/Images/dress9.jpg";
                photo25.Priority = true;
                photo26.PhotoUrl = "~/Images/dress9.jpg";
                photo26.Priority = false;
                photo27.PhotoUrl = "~/Images/dress9.jpg";
                photo27.Priority = false;
                photo28.PhotoUrl = "~/Images/dress10.jpg";
                photo28.Priority = true;
                photo29.PhotoUrl = "~/Images/dress10.jpg";
                photo29.Priority = false;
                photo30.PhotoUrl = "~/Images/dress10.jpg";
                photo30.Priority = false;
              

                #endregion
                //формируем продукт
                #region создаем несколько Продуктов
                
                product1.Name = "Офигеть не встать!";
                product1.Description = "Сшито капроновыми нитками в подполье";
                product1.Photo.Add(photo1);
                product1.Photo.Add(photo2);
                product1.Photo.Add(photo3);
                product1.Price = 1200;
                product1.SpecOffer = "Купи и леденец в подарок!";
                product1.DateCreate = Now;
                Thread.Sleep(10);
                
                product2.Name = "С будуна";
                product2.Description = "Косо криво - абы живо!";
                product2.Photo.Add(photo4);
                product2.Photo.Add(photo5);
                product2.Photo.Add(photo6);
                product2.Price = 500;
                product2.SpecOffer = "Обучим пьяному стилю";
                product2.DateCreate = Now;
                Thread.Sleep(10);
                
                product3.Name = "На глаз";
                product3.Description = "а и правда - зачем выкройка?";
                product3.Photo.Add(photo7);
                product3.Photo.Add(photo8);
                product3.Photo.Add(photo9);
                product3.Price = 4200;
                product3.DateCreate = Now;
                Thread.Sleep(10);
                
                product4.Name = "Очумелые ручки";
                product4.Description = "Настолько очумели - что вот такое пошили!";
                product4.Photo.Add(photo10);
                product4.Photo.Add(photo11);
                product4.Photo.Add(photo12);
                product4.Price = 200;
                product4.DateCreate = Now;
                Thread.Sleep(10);
                
                product5.Name = "Веселая леди";
                product5.Description = "Оцените всю веселость этой леди!";
                product5.Photo.Add(photo13);
                product5.Photo.Add(photo14);
                product5.Photo.Add(photo15);
                product5.Price = 1200;
                product5.DateCreate = Now;
                Thread.Sleep(10);
                
                product6.Name = "Показуха";
                product6.Description = "Это платье давно уже купили - но вот, посмотрите какая красотааа!";
                product6.Photo.Add(photo16);
                product6.Photo.Add(photo17);
                product6.Photo.Add(photo18);
                product6.Price = 1200;
                product6.DateCreate = Now;
                Thread.Sleep(10);
                
                product7.Name = "Выставочно платьеце";
                product7.Description = "Просто похвастаться";
                product7.Photo.Add(photo19);
                product7.Photo.Add(photo20);
                product7.Photo.Add(photo21);
                product7.Price = 1200;
                product7.DateCreate = Now;
                Thread.Sleep(10);
                
                product8.Name = "Вырви глаз";
                product8.Description = "Специальная психо-физичесская методика пошива, позволяет выстно улучшить ваше зрение!";
                product8.Photo.Add(photo22);
                product8.Photo.Add(photo23);
                product8.Photo.Add(photo24);
                product8.Price = 8200;
                product8.SpecOffer = "+ поход к окулисту!";
                product8.DateCreate = Now;
                Thread.Sleep(10);
                
                product9.Name = "Мольба конкурента";
                product9.Description = "произведенно соседкой по койке";
                product9.Photo.Add(photo25);
                product9.Photo.Add(photo26);
                product9.Photo.Add(photo27);
                product9.Price = 3300;
                product9.SpecOffer = "Купи - обрадуй соседку!";
                product9.DateCreate = Now;
                Thread.Sleep(10);
                
                product10.Name = "Вокруг китай";
                product10.Description = "Маде ин чина";
                product10.Photo.Add(photo28);
                product10.Photo.Add(photo29);
                product10.Photo.Add(photo30);
                product10.Price = 100;
                product10.DateCreate = Now;

                #endregion

                
                //формируем заказы для проверки БД

                #region создаем несколько заказов
                
                orders1.ClientName = "Жора Забугорный";
                orders1.Email = "sergeyderko@gmail.com";
                orders1.Phone = "096 327 03 56";
                orders1.Comments = "Проверка заполнения базы и отправки письма на почту";
                orders1.Product.Add(product1);
                orders1.Product.Add(product2);
                orders1.Sum = product1.Price + product2.Price;
                orders1.Sity = "Киев";
                orders1.Delivery = ukrMail;
                orders1.Status = inProcessing;
                orders1.DateOrder = Now;
                orders1.Delivery.DeliveryId = orders1.OrderId;

                
                orders2.ClientName = "Жора Забугорный";
                orders2.Email = "sergeyderko@gmail.com";
                orders2.Phone = "096 327 03 56";
                orders2.Comments = "Проверка заполнения базы и отправки письма на почту";
                orders2.Product.Add(product3);
                orders2.Sum = product3.Price;
                orders2.Sity = "Киев";
                orders2.Delivery = newMail;
                orders2.Delivery.DeliveryId = orders2.OrderId;
                orders2.Status = newOrder;
                orders2.DateOrder = Now;
                
                orders3.ClientName = "Жора Забугорный";
                orders3.Email = "sergeyderko@gmail.com";
                orders3.Phone = "096 327 03 56";
                orders3.Comments = "Проверка заполнения базы и отправки письма на почту";
                orders3.Product.Add(product4);
                orders3.Product.Add(product5);
                orders3.Sum = product4.Price + product5.Price;
                orders3.Sity = "Киев";
                orders3.Delivery = selfCatering;
                orders3.Delivery.DeliveryId = orders3.OrderId;
                orders3.Status = ready;
                orders3.DateOrder = Now;

                #endregion
                //добавляем сущьности в базу

        #region Добавляем все в базу

                db.Category.Add(sale);
                db.Category.Add(gallery);
                db.Category.Add(partners);

                db.Status.Add(newOrder);
                db.Status.Add(inProcessing);
                db.Status.Add(ready);

                db.Delivery.Add(ukrMail);
                db.Delivery.Add(newMail);
                db.Delivery.Add(selfCatering);

                db.Reviews.Add(reviews1);
                db.Reviews.Add(reviews2);
                db.Reviews.Add(reviews3);
                db.Reviews.Add(reviews4);
                db.Reviews.Add(reviews5);

                //db.Photo.Add(photo1);
                //db.Photo.Add(photo2);
                //db.Photo.Add(photo3);
                //db.Photo.Add(photo4);
                //db.Photo.Add(photo5);
                //db.Photo.Add(photo6);
                //db.Photo.Add(photo7);
                //db.Photo.Add(photo8);
                //db.Photo.Add(photo9);
                //db.Photo.Add(photo10);
                //db.Photo.Add(photo11);
                //db.Photo.Add(photo12);
                //db.Photo.Add(photo13);
                //db.Photo.Add(photo14);
                //db.Photo.Add(photo15);
                //db.Photo.Add(photo16);
                //db.Photo.Add(photo17);
                //db.Photo.Add(photo18);
                //db.Photo.Add(photo19);
                //db.Photo.Add(photo20);
                //db.Photo.Add(photo21);
                //db.Photo.Add(photo22);
                //db.Photo.Add(photo23);
                //db.Photo.Add(photo24);
                //db.Photo.Add(photo25);
                //db.Photo.Add(photo26);
                //db.Photo.Add(photo27);
                //db.Photo.Add(photo28);
                //db.Photo.Add(photo29);
                //db.Photo.Add(photo30);

                db.Product.Add(product1);
                db.Product.Add(product2);
                db.Product.Add(product3);
                db.Product.Add(product4);
                db.Product.Add(product5);
                db.Product.Add(product6);
                db.Product.Add(product7);
                db.Product.Add(product8);
                db.Product.Add(product9);
                db.Product.Add(product10);

                db.Orders.Add(orders1);
                db.Orders.Add(orders2);
                db.Orders.Add(orders3);

                db.SaveChanges();


                #endregion

            }
        }

    }
}