using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entityes;

namespace DressShopWebUI.Models
{
    public class Basket
    {
        /// <summary>
        /// коллекция товаров в корзине
        /// </summary>
        private readonly List<Photo> _myCollection = new List<Photo>();

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
            if (!_myCollection.Exists(x=>x.Product.ProductId == product.Product.ProductId))
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
        public decimal ComputeTotalValue()
        {
            return _myCollection.Sum(x =>x.Product.Price);
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
