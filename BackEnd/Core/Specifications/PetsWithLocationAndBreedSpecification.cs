using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Enitites;
using Core.Specifications.Helpers;
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

            //Page:1
            //PageSize:5
            //ApplyPaging(skip: ???, take: PageSize)
            //Because PageIndex starts with 1 we have to decrease it by 1
            //so we don't skip any objects at start
            // 5 * (1 - 1) = 0, so we skip 0 at first page
            // 5 * (2 - 1) = 5 - we skip 5 objects
            ApplyPaging(parameters.PageSize * (parameters.PageIndex - 1), parameters.PageSize);
        }

        private static Expression<Func<Pet, bool>> SetFilters(PetSpecificationParameters parameters)
        {
            // return p =>
            //     CriteriaConfigurationHelper.IfHasParameter(p.BreedId, parameters.BreedId)
            //     && CriteriaConfigurationHelper.IfHasParameter(p.Adress.CityId, parameters.CityId)
            //     && CriteriaConfigurationHelper.IfHasParameter(
            //         p.Breed.AnimalsId,
            //         parameters.AnimalsId
            //     )
            //     && CriteriaConfigurationHelper.IfHasParameter(p.Name, parameters.Search);


            return expr;
        }

        private static Func<Pet, bool> Bar = O;

        private static bool O(Pet p)
        {
            return false;
        }

        static Expression<Func<Pet, bool>> expr = p => Foo(p, 12);

        private static bool Foo(Pet p, int a)
        {
            return p.BreedId == a;
        }
    }
}
