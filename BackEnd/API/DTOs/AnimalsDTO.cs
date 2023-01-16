using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public record AnimalsDTO : BaseDTO
    {
        public string CollectionName { get; init; } = string.Empty;
        public List<string> Breeds { get; init; } = new List<string>();
    }
}
