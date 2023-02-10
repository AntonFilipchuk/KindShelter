namespace Core.Entities
{
    public record Animal : BaseEntity
    {
        public required string AnimalName { get; init; }
        public required string PluralAnimalName {get; init;}
        public IEnumerable<Breed>? Breeds { get; init; }

        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<AnimalProduct>? AnimalProducts { get; init; }

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
