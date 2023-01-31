using Core.Entities;
using Core.Specifications.Parameters;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class PetsWithLocationAndBreedSpecification : BaseSpecification<Pet>
    {
        public PetsWithLocationAndBreedSpecification(PetSpecificationParameters parameters)
            : base(
                p =>
                    (parameters.BreedId == null || p.BreedId == parameters.BreedId)
                    && (parameters.AnimalsId == null || p.Breed!.AnimalId == parameters.AnimalsId)
            )
        {
            AddInclude(p => p.Breed!.Animal!);

            //Page:1
            //PageSize:5
            //ApplyPaging(skip: ???, take: PageSize)
            //Because PageIndex starts with 1 we have to decrease it by 1
            //so we don't skip any objects at start
            // 5 * (1 - 1) = 0, so we skip 0 at first page
            // 5 * (2 - 1) = 5 - we skip 5 objects
            ApplyPaging(parameters.PageSize * (parameters.PageIndex - 1), parameters.PageSize);
        }
    }
}
