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

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _context.Animals.Include(a => a.BreedType).ToListAsync();
            //return await _context.BreedTypes.Include(bt => bt.Animals).ToListAsync();
        }

        public async Task<IEnumerable<BreedType>> GetBreeds()
        {
             return await _context.BreedTypes.Include(bt => bt.Animals).ToListAsync();
        }

        public async Task<IEnumerable<Breeds>> GetBreedsCollection()
        {
            return await _context.BreedsCollection.Include(b => b.BreedTypesCollection).ToListAsync();
        }
    }
}