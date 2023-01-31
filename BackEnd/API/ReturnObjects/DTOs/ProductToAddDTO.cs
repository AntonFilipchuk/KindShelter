using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ReturnObjects.DTOs
{
    public record ProductToAddDTO : BaseDTO
    {
        public required string ProductName { get; init; }
        public int ProductQuantity { get; init; }
        public string? ProductDescription { get; init; }
        public decimal ProductPrice { get; init; }
        public required int ProductTypeId { get; init; }
        public required int BrandId { get; init; }
    }
}
