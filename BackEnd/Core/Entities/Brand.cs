namespace Core.Entities
{
    public record Brand : BaseEntity
    {
        public required string BrandName { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
