using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites
{
    public record City : BaseEntity
    {
        public required string CityName { get; init; }
        public required IEnumerable<Adress> Adresses { get; init; }

        public int GetNumberOfAdresses()
        {
            return Adresses is null ? 0 : Adresses.Count();
        }
    }
}
