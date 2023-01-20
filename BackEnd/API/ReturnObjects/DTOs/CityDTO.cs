using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ReturnObjects.DTOs
{
    public record CityDTO : BaseDTO
    {
        public string CityName { get; init; } = default!;
        public int NumberOfAdresses { get; init; }
    }
}