using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entityes;

namespace DressShopWebUI.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);// всего страниц
    }
    public class SellingViewModel
    {
        public IEnumerable<Photo> Photo { get; set; }
        public PageInfo PageInfo { get; set; }
    }
    public class PartnersViewModel
    {
        public IEnumerable<Photo> Photo { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}