namespace Core.Entities
{
    public record ProductType : BaseEntity
    {
        public required string ProductTypeName { get; init; }
        public IEnumerable<Product>? Products { get; init; }
    }
}
