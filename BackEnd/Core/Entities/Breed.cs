namespace Core.Entities
{
    public record Breed : BaseEntity
    {
        public required string BreedName { get; init; }
        public IEnumerable<Pet>? Pets { get; init; }

        //Navigation Properties
        public Animal? Animal { get; init; }
        public required int AnimalId { get; init; }

        public int GetNumberOfPets()
        {
            return Pets == null ? 0 : Pets.Count();
        }
    }
}
