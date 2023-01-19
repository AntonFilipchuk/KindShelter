using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites
{
    public record BaseEntity
    {
        public required int Id {get; init;}
    }
}