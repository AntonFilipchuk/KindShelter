namespace Core.Entities
{
    public record Animal : BaseEntity
    {
        public required string AnimalName { get; init; }
        public required IEnumerable<Breed> Breeds { get; init; }

        public IEnumerable<Product>? Products { get; set; }

        public List<string> GetBreedsList()
        {
            List<string> breeds = new List<string>();
            if (Breeds is null)
            {
                return breeds;
            }
            foreach (var breed in Breeds)
            {
                breeds.Add(breed.BreedName);
            }
            return breeds;
        }

    }
}
