using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites
{
    public record Location : BaseEntity
    {
        public string City {get; init;} = string.Empty;
        public string? Street {get; init;}
        public int? House {get; init;}
        public int? FlatNumber {get; init;}
    }
}