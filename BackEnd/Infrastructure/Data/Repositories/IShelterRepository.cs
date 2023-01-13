using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Core.Enitites.Breeds;

namespace Infrastructure.Data.Repositories
{
    public interface IShelterRepository
    {
        Task<IEnumerable<Pet>> GetAnimals();
        Task<IEnumerable<Animal>> GetBreedsCollection();
        Task<IEnumerable<Breed>> GetBreeds();
        //Task<IEnumerable<BreedType>> GetBreedTypes();
    }
}
