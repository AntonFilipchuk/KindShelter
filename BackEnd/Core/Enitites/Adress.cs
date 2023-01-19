using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites
{
    public record Adress : BaseEntity
    {
        public string Street { get; init; } = default!;
        public int? HouseNumber { get; init; }
        public int? FlatNumber { get; init; }

        //Navigation properties
        public required City City {get; init;}
        public required int CityId {get; init;}
    }
}
