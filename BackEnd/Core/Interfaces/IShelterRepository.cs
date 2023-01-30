using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;


namespace Core.Interfaces
{
    public interface IShelterRepository
    {
        Task<IEnumerable<Pet>> GetPetsAsync();
        Task<IEnumerable<Animal>> GetAnimalsAsync();
        Task<IEnumerable<Breed>> GetBreedsAsync();
        Task<Pet?> GetPetByIdAsync(int id);
        Task<Breed?> GetBreedByIdAsync(int id);
        Task<Animal?> GetAnimalsByIdAsync(int id);
    }
}
