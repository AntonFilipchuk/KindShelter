using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites
{
    public record Animals : BaseEntity
    {
        public string CollectionName { get; init; } = string.Empty;
        public IEnumerable<Breed>? Breeds {get; init;}

        public List<string> BreedsList()
        {
            List<string> breeds = new List<string>();
            if (Breeds is null)
            {
                return breeds;
            }
            foreach(var breed in Breeds)
            {
                breeds.Add(breed.BreedName);
            }
            return breeds;
        }
        
    }
}
