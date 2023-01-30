namespace Core.Entities
{
    public record Breed : BaseEntity
    {
        public required string BreedName { get; init; }
        public required IEnumerable<Pet> Pets { get; init; }

        //Navigation Properties
        public required Animal Animal { get; init; }
        public required int AnimalId { get; init; }

        public int GetNumberOfPets()
        {
            return Pets.Count();
        }
    }
}
