using System.Collections.Generic;
using Domain.Entityes;

namespace DressShopWebUI.Models
{
    public class Basket
    {
       public Basket()
        {
            AnswerList = new List<string>();
        }
        /// <summary>
        /// коллекция товаров в корзине
        /// </summary>
        private readonly List<Photo> _myCollection = new List<Photo>();


        //ответ пользователю
        public List<string> AnswerList { get; set; }
        public IEnumerable<Photo> Lines => _myCollection;

        /// <summary>
        /// количество товаров в корзине
        /// </summary>
        public int CountItem => _myCollection.Count;

        /// <summary>
        /// добавление товара в корзину
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Photo product)
        {
            //проверка на наличии в корзине идентичных тваров
            if (!_myCollection.Exists(x=>x.PhotoId == product.PhotoId))
            _myCollection.Add(product); // если такого продукта нет в корзине - добавляем
        }

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Photo product)
        {
            _myCollection.RemoveAll(x => x.Product.ProductId == product.Product.ProductId);
        }

        /// <summary>
        /// получаем сумму товаров
        /// </summary>
        /// <returns></returns>
        public double ComputeTotalValue()
        {
            double totalVelue = 0;
            foreach (var i in _myCollection)
            {
                if (i.Product.Discount != 0)
                {

                    totalVelue += i.Product.Price - i.Product.Price * i.Product.Discount/100;

                }
                else
                {
                    totalVelue += i.Product.Price;
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
