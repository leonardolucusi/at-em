namespace Domain.Product
{
    public class Measure
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public short Height { get; set; }
        public short Width { get; set; }
        public short Depth { get; set; }
        public int Weight { get; set; }
        
        public virtual Product? Product { get; set; }
    }
}
