using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites
{
    public record Animals : BaseEntity
    {
        public required string CollectionName { get; init; }
        public required IEnumerable<Breed> Breeds {get; init;}

        public List<string> GetBreedsList()
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
