using System.Collections.Generic;
using Domain.Entityes;

namespace Domain.Abstrac
{
    /// <summary>
    /// Интерфейс возвращающий коллекцию отзывов из БД
    /// </summary>
    public interface IReviewsRepository
    {
        IEnumerable<Reviews>Reviewses { get; }
        void SaveReview(Reviews reviews);
        void RemoveReview(Reviews reviews);
    }
}