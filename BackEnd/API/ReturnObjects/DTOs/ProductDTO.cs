namespace API.ReturnObjects.DTOs
{
    public record ProductDTO : BaseDTO
    {
        public required string ProductName { get; init; }
        public int ProductQuantity { get; init; }
        public string? ProductDescription { get; init; }
        public decimal ProductPrice { get; init; }
        public required string ProductType { get; init; }
        public required string Brand { get; init; }
        public required string PictureUrl { get; init; }
    }
}
