using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithProductTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductWithProductTypeAndBrandSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.Brand!);
            AddInclude(p => p.ProductType!);
        }
    }
}
