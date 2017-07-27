﻿using System;
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
        public decimal ComputeTotalValue()
        {
            decimal totalVelue = 0;
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