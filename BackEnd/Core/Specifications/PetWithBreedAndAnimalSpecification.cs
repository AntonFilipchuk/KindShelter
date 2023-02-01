using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class PetWithBreedAndAnimalSpecification : BaseSpecification<Pet>
    {
        public PetWithBreedAndAnimalSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.Breed!.Animal!);
        }

        
    }
}
