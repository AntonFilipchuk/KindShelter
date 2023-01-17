using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;


namespace Core.Interfaces
{
    public interface IShelterRepository
    {
        Task<IEnumerable<Pet>> GetPetsAsync();
        Task<IEnumerable<Animals>> GetAnimalsAsync();
        Task<IEnumerable<Breed>> GetBreedsAsync();
        Task<Pet?> GetPetByIdAsync(int id);
        Task<Breed?> GetBreedByIdAsync(int id);
        Task<Animals?> GetAnimalsByIdAsync(int id);
    }
}
