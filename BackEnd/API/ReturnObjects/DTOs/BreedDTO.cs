namespace API.ReturnObjects.DTOs
{
    public record BreedDTO : BaseDTO
    {
        public required string Animal { get; init; }
        public required string BreedName { get; init; }
        public int NumberOfPets { get; init; }
    }
}