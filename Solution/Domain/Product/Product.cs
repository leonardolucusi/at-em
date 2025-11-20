namespace Domain.Product
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get;set; }
        public double SellingPrice { get; set; }
        
        public virtual ICollection<Measure>? Measures { get; set; }
    }
}
