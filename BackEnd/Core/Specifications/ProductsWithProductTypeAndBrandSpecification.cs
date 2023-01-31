using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications.Parameters;

namespace Core.Specifications
{
    public class ProductsWithProductTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandSpecification(
            ProductSpecificationParameters parameters
        )
            : base(
                p =>
                    (parameters.BrandId == null || p.BrandId == p.BrandId)
                    && (
                        parameters.ProductTypeId == null
                        || p.ProductTypeId == parameters.ProductTypeId
                    )
            )
        {
            AddInclude(p => p.Brand!);
            AddInclude(p => p.ProductType!);
            ApplyPaging(parameters.PageSize * (parameters.PageIndex - 1), parameters.PageSize);
        }
    }
}
