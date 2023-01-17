using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Enitites;

namespace Core.Specifications
{
    public class PetWithLocationAndBreedSpecification : BaseSpecification<Pet>
    {
        public PetWithLocationAndBreedSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.Breed.Animals);
        }

        
    }
}
