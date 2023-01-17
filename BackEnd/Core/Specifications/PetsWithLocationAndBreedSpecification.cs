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
            : base(expression)
        {
            AddInclude(p => p.Breed!.Animals!);
        }

        static Expression<Func<Pet, bool>> expression = p => p.BreedId == 1;
    }
}
