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
        Task<IEnumerable<Pet>> GetPets();
        Task<IEnumerable<Animal>> GetAnimals();
        Task<IEnumerable<Breed>> GetBreeds();
    }
}
