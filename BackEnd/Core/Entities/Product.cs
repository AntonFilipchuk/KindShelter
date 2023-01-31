namespace Core.Entities
{
    public record Product : BaseEntity
    {
        public required string ProductName { get; init; }
        public required int ProductQuantity { get; init; }
        public string? ProductDescription { get; init; }
        public required decimal ProductPrice { get; init; }

        public IEnumerable<Animal>? Animals { get; init; }
        public IEnumerable<AnimalProduct>? AnimalProducts {get; init;}

        public ProductType? ProductType { get; init; }
        public required int ProductTypeId { get; init; }

        public Brand? Brand { get; init; }
        public required int BrandId { get; set; }


    }
}
