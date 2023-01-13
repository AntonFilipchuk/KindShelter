using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Core.Enitites.Breeds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly ShelterContext _context;
        public ShelterRepository(ShelterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pet>> GetAnimals()
        {
            return await _context.Pets.Include(a => a.Breed).ToListAsync();
            //return await _context.BreedTypes.Include(bt => bt.Animals).ToListAsync();
        }

        public async Task<IEnumerable<Breed>> GetBreeds()
        {
             return await _context.Breeds.Include(bt => bt.Animal).ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetBreedsCollection()
        {
            return await _context.Animals.Include(b => b.Breeds).ToListAsync();
        }
    }
}