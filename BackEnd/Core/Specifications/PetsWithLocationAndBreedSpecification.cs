using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Enitites;
using Core.Specifications.Parameters;

namespace Core.Specifications
{
    public class PetsWithLocationAndBreedSpecification : BaseSpecification<Pet>
    {
        public PetsWithLocationAndBreedSpecification(PetSpecificationParameters parameters)
            : base(SetFilters(parameters))
        {
            AddInclude(p => p.Breed.Animals);
            AddInclude(p => p.Adress.City);
        }

        private static Expression<Func<Pet, bool>> SetFilters(PetSpecificationParameters parameters)
        {
            return p =>
                (!parameters.BreedId.HasValue || p.BreedId == parameters.BreedId)
                && (
                    !parameters.CityId.HasValue
                    || (p.Adress == null ? false : p.Adress.CityId == parameters.CityId)
                );
        }
    }
}
