using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ReturnObjects.DTOs
{
    public record AdressDTO : BaseDTO 
    { 
        public string Street { get; set; } = default!;
        public int? HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
    }
}
