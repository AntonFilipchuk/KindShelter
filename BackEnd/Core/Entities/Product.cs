namespace Core.Entities
{
    public record Product : BaseEntity
    {
        public required string ProductName { get; init; }
        public int ProductQuantity { get; init; }
        public string? ProductDescription { get; init; }
        public decimal ProductPrice { get; init; }

        public IEnumerable<Animal>? Animals { get; init; }

        public required ProductType ProductType { get; init; }
        public required int ProductTypeId { get; init; }

        public required Brand Brand { get; init; }
        public required int BrandId { get; set; }
    }
}
