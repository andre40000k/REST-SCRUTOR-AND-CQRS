using ShopMeneger.Data.Models;

namespace ShopMeneger.Contracts.Respons
{
    public class ShopResponse
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopDescription { get; set; }

        public Shop UpsertShop()
        {
            return new Shop
            {
                ShopId = ShopId,
                ShopName = ShopName,
                ShopDescription = ShopDescription
            };
        }
    }
}
