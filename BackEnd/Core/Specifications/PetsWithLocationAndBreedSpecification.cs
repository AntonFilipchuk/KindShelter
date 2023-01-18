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
            : base(SetFilter(parameters))
        {
            //TODO: null check
            AddInclude(p => p.Breed!.Animals!);
            AddInclude(p => p.Adress!.City);
        }

        private static Expression<Func<Pet, bool>> SetFilter(PetSpecificationParameters parameters)
        {
            return p => p.BreedId == parameters.BreedId;
        }
    }
}
