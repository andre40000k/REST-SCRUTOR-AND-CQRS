namespace ShopMeneger.Data.Models
{
    public class Shop
    {
        public Guid ShopId { get; set; }



        public string ShopName { get; set; }
        public string ShopDescription { get; set; }



        public virtual IEnumerable<Category> Categories { get; set; }
    }
}
