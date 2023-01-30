namespace API.ReturnObjects.DTOs
{
    public record PetDTO : BaseDTO
    {
        public required string Name { get; init; }
        public decimal Price { get; init; }
        public required string PictureUrl { get; init; }
        public int Age { get; init; } = 1;
        public required string Gender { get; init; }
        public required string Color { get; init; }
        public required string Breed { get; init; }
        public required string Animal { get; init; }
        public string? Description { get; init; }
        public bool? HasVaccines { get; init; } = false;
    }
}
