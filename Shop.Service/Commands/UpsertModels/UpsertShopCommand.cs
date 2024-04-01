using ShopMeneger.Data.Models;

namespace ShopMeneger.Service.Commands.UpsertModels
{
    public class UpsertShopCommand
    {
        public string ShopName { get; set; }
        public string ShopDescription { get; set; }

        public Shop UpsertShop()
        {
            return new Shop
            {
                ShopName = ShopName,
                ShopDescription = ShopDescription
            };
        }
    }
}
