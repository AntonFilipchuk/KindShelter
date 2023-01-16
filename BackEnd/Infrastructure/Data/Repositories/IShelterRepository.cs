using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;


namespace Infrastructure.Data.Repositories
{
    public interface IShelterRepository
    {
        Task<IEnumerable<Pet>> GetPets();
        Task<IEnumerable<Animals>> GetAnimals();
        Task<IEnumerable<Breed>> GetBreeds();
    }
}
