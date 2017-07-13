using Domain.Concrete;
using static System.DateTime;
using Domain.Entityes;

namespace DressShopWebUI.Models
{
    public class AddReviews
    {
        public static void Add(string name, string review, int rating)
        {
            using (var db = new ShopContext())
            {
                db.Reviews.Add(new Reviews
                {
                    ClientName = name,
                    ClientFeedback = review,
                    Rating = rating,
                    DateFeedback = Now
                });
                db.SaveChanges();
            }
        }
    }
}