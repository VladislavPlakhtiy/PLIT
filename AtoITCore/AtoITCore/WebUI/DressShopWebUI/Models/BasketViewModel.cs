
namespace DressShopWebUI.Models
{

    public class BasketViewModel
    {
        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }

        //поле с сущьность для оформления покупки
        public Orders Orders { get; set; }

    }
}