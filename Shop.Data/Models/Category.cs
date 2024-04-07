namespace ShopMeneger.Data.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public Guid ShopId { get; set; }



        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }



        public virtual Shop Shop { get; set; }
        public virtual IEnumerable<Product> Products { get; set;}
    }
}
