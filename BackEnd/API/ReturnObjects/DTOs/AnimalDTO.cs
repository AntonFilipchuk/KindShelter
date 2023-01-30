namespace API.ReturnObjects.DTOs
{
    public record AnimalDTO : BaseDTO
    {
        public required string AnimalName { get; init; }
    }
}
