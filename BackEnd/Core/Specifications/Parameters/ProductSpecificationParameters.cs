using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Specifications.Parameters
{
    public class ProductSpecificationParameters : IParameters
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 7;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public int? ProductTypeId { get; set; }
        public int? BrandId { get; set; }

        private string? _search;
        public string? Search
        {
            get { return _search; }
            set { _search = value is null ? null : value.ToLower(); }
        }
    }
}
