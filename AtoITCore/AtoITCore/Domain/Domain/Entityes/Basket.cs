using System.Collections.Generic;

namespace Domain.Entityes
{
    
    /// <summary>
    /// Сущность для хранения покупок в сессии
    /// </summary>
    public class Basket
    {
        public Basket()
        {
            AnswerList = new List<string>();
        }
        /// <summary>
        /// коллекция товаров в корзине
        /// </summary>
        private readonly List<Product> _myCollection = new List<Product>();


        //ответ пользователю
        public List<string> AnswerList { get; set; }
        public IEnumerable<Product> Lines => _myCollection;

        /// <summary>
        /// количество товаров в корзине
        /// </summary>
        public int CountItem => _myCollection.Count;

        /// <summary>
        /// добавление товара в корзину
        /// </summary>
        public void AddProduct(Product product)
        {
            //проверка на наличии в корзине идентичных тваров
            if (!_myCollection.Exists(x => x.ProductId == product.ProductId))
                _myCollection.Add(product); // если такого продукта нет в корзине - добавляем
        }

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        public void RemoveProduct(Product product)
        {
            _myCollection.RemoveAll(x => x.ProductId == product.ProductId);
        }

        /// <summary>
        /// получаем сумму товаров
        /// </summary>
        public double ComputeTotalValue()
        {
            double totalVelue = 0;
            foreach (var i in _myCollection)
            {
                if (i.Discount != 0)
                {

                    totalVelue += i.Price - i.Price * i.Discount / 100;

                }
                else
                {
                    totalVelue += i.Price;
                }
            }
            return totalVelue;
        }

        /// <summary>
        /// очистка козины
        /// </summary>
        public void Clear()
        {
            _myCollection.Clear();
        }


    }
}
