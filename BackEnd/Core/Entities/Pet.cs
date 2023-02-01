namespace Core.Entities
{
    public record Pet : BaseEntity
    {
        public required string Name { get; init; }
        public decimal Price { get; init; }
        public required string PictureUrl { get; init; }
        public required int Age { get; init; }
        public required string Gender { get; init; }
        public required string Color { get; init; }
        public bool? HasVaccines { get; init; } = false;
        public string? Description { get; init; }

        //Navigation properties
        public Breed? Breed { get; init; }
        public required int BreedId { get; init; }
    }
}
