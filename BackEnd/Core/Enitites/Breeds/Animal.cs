using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites.Breeds
{
    public record Animal : BaseEntity
    {
        public string AnimalName { get; init; } = string.Empty;
        public IEnumerable<Breed>? Breeds {get; init;}
    }
}
