using System;
using System.Collections.Generic;
using Domain.Abstrac;
using Domain.Entityes;
using static System.DateTime;


namespace Domain.Concrete
{
    public class EfReviewRepository : IReviewsRepository
    {
        readonly ShopContext _context = new ShopContext();
        public IEnumerable<Reviews> Reviewses => _context.Reviews;
        public void SaveReview(Reviews reviews)
        {
            if (reviews.ReviewId == 0)
            {
                //проверяем наличие рейтинга заполненого пользователем.
                var rating = string.IsNullOrEmpty(reviews.Rating.ToString()) ? 0 : int.Parse(reviews.Rating.ToString());
                //Добавляем отзыв
                _context.Reviews.Add(new Reviews
                {
                    ClientName = reviews.ClientName,
                    ClientFeedback = reviews.ClientFeedback,
                    Rating = rating,
                    Email = reviews.Email,
                    Advantages = reviews.Advantages,
                    LackOf = reviews.LackOf,
                    DateFeedback = Now
                });
                _context.SaveChanges();
            }
            else
            {
                Reviews rew = _context.Reviews.Find(reviews.ReviewId);
                if (rew != null)
                {
                    rew.ClientName = reviews.ClientName;
                    rew.ClientFeedback = reviews.ClientFeedback;
                    rew.Rating = reviews.Rating;
                    rew.Email = reviews.Email;
                    rew.Advantages = reviews.Advantages;
                    rew.LackOf = reviews.LackOf;
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }

        public void RemoveReview(Reviews reviews)
        {
            Reviews rew = _context.Reviews.Find(reviews.ReviewId);
            if (rew != null)
            {
                _context.Reviews.Remove(rew);
                _context.SaveChanges();
            }
            else
                throw new Exception();
        }
    }
}
