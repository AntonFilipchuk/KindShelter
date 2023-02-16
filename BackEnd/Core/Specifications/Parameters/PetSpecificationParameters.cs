using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Specifications.Parameters
{
    public class PetSpecificationParameters : IParameters
    {
        //Pagination parameters
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 12;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        //Sorting by id parameters
        public int? BreedId { get; set; }
        public int? AnimalsId { get; set; }

        //Sort by vaccines
        public bool? VaccinationStatus {get; set;}
    

        //Type of sorting (asc/desc)
        public string? Sort { get; set; }

        //For searching by string
        private string? _search;
        public string? Search
        {
            get { return _search; }
            set { _search = value is null ? null : value.ToLower(); }
        }
    }
}
