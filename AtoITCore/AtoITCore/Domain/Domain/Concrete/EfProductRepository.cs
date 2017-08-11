using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.Abstrac;
using Domain.Entityes;
using static System.DateTime;

namespace Domain.Concrete
{
    public class EfProductRepository : IProductRepository
    {
        readonly ShopContext _context = new ShopContext();
        public IEnumerable<Product> Products => _context.Product;

        //Добавление и редактирование продукта
        public void SaveProduct(Product product, List<Photo> list)
        {
            if (product.ProductId == 0)
            {
                try
                {
                    _context.Product.Add(new Product
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Discount = product.Discount,
                        Category = product.Category,
                        Price = product.Price,
                        SpecOffer = product.SpecOffer,
                        DateCreate = Now,
                        Photo = list
                    });
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                Product pro = _context.Product.Find(product.ProductId);
                if (pro != null)
                {
                    pro.Name = product.Name;
                    pro.Description = product.Description;
                    pro.Discount = product.Discount;
                    pro.Category = product.Category;
                    pro.Price = product.Price;
                    pro.SpecOffer = product.SpecOffer;
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }

        //Удаление продукта
        public void RemoveProduct(int productId, DirectoryInfo directory)
        {
            List<string> urList = new List<string>();
            Product pro = _context.Product.FirstOrDefault(x=>x.ProductId == productId);
            if (pro != null)
            {
                var photoFromRemove = _context.Photo.Where(x => x.Product.ProductId == productId);
                foreach (var i in photoFromRemove)
                {
                        urList.Add(i.PhotoUrl);
                        _context.Photo.Remove(i);
                }
                _context.Product.Remove(pro);
                _context.SaveChanges();

                foreach (FileInfo file in directory.GetFiles()) //Удаление фото из директории пока закоментирую для удобства 
                {
                    if (urList.Contains(file.ToString()))
                        file.Delete();
                }
            }
            else
                throw new Exception();
        }

        //Добавление фото к продукту
        public void SavePhoto(int productId, string url)
        {
            var oneProduct = _context.Product.FirstOrDefault(x=>x.ProductId== productId);
            if (oneProduct != null)
            {
                try
                {
                    if (oneProduct.Photo.Count == 0)
                    {
                        oneProduct.Photo.Add(new Photo
                        {
                            PhotoUrl = url,
                            Priority = true
                        });
                        _context.SaveChanges();
                    }
                    else
                    {
                        oneProduct.Photo.Add(new Photo
                        {
                            PhotoUrl = url,
                            Priority = false
                        });
                        _context.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
                throw new Exception();
        }

        //Удаление фото
        public void RemovePhoto(int productId, int photoId, DirectoryInfo directory)
        {
            var oneProduct = _context.Product.FirstOrDefault(x=>x.ProductId == productId);
            var onePhoto = _context.Photo.FirstOrDefault(x => x.PhotoId == photoId);
            if (oneProduct != null && onePhoto != null)
            {
                try
                {
                    var urlDell = onePhoto.PhotoUrl; 
                    _context.Photo.Remove(onePhoto);
                    _context.SaveChanges();
                    foreach (FileInfo file in directory.GetFiles()) //Пока закоментирую, для удобства
                    {
                        if (file.ToString() == urlDell)
                            file.Delete();
                    }
                    if (oneProduct.Photo.Any()) //Проверяем, остались ли фото в базе по продукту
                    {
                        if (oneProduct.Photo.FirstOrDefault(x => x.Priority) == null)
                        {
                            var priorityСhangesPhoto = oneProduct.Photo.FirstOrDefault(x => x.Priority == false);
                            if (priorityСhangesPhoto != null) priorityСhangesPhoto.Priority = true;
                            _context.SaveChanges();
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
                throw new Exception();
        }

        //Смена приоритета фото
        public void PriorityСhangesPhoto(int productId, int photoId)
        {
                try
                {
                    var selectProduct = _context.Product.FirstOrDefault(x=>x.ProductId == productId);
                    if (selectProduct != null)
                        foreach (var i in selectProduct.Photo)
                        {
                            if (i != null)
                                i.Priority = false;
                        }
                    var selectPhoto = _context.Photo.FirstOrDefault(x=>x.PhotoId == photoId);
                    if (selectPhoto != null) selectPhoto.Priority = true;
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }
}
