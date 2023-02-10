namespace API.ReturnObjects.DTOs
{
    public record AnimalDTO : BaseDTO
    {
        public required int Id {get; set;}
        public required string AnimalName { get; init; }
        public required string PluralAnimalName {get; init;}
    }
}
