using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly ShelterContext _context;

        public ShelterRepository(ShelterContext context, ILogger<ShelterRepository> logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pet>> GetPetsAsync()
        {
            return await _context.Pets!
                .Include(pet => pet.Breed)
                .ThenInclude(x => x!.Animals)
                .Include(pet => pet.Location)
                .ToListAsync();
        }

        public async Task<IEnumerable<Breed>> GetBreedsAsync()
        {
            return await _context.Breeds!
                .Include(breed => breed.Animals)
                .Include(breed => breed.Pets)
                .ToListAsync();
        }

        public async Task<IEnumerable<Animals>> GetAnimalsAsync()
        {
            return await _context.Animals!.Include(animals => animals.Breeds).ToListAsync();
        }

        public async Task<Pet?> GetPetByIdAsync(int id)
        {
            return await _context.Pets!
                .Include(p => p.Breed)
                .ThenInclude(b => b!.Animals)
                .Include(pet => pet.Location)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Breed?> GetBreedByIdAsync(int id)
        {
            return await _context.Breeds!
                .Include(breed => breed.Animals)
                .Include(breed => breed.Pets)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Animals?> GetAnimalsByIdAsync(int id)
        {
            return await _context.Animals!
                .Include(animals => animals.Breeds)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
