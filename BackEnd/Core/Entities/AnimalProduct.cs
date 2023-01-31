using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public record AnimalProduct
    {
        public Animal? Animal {get; init;}
        public required int AnimalId {get; init;}

        public Product? Product {get; init;}
        public required int ProductId {get; init;}
    }
}