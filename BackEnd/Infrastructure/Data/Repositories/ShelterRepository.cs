using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
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
                .ThenInclude(breed => breed!.Animal)
                .ToListAsync();
        }

        public async Task<IEnumerable<Breed>> GetBreedsAsync()
        {
            return await _context.Breeds!
                .Include(breed => breed.Animal)
                .Include(breed => breed.Pets)
                .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetAnimalsAsync()
        {
            return await _context.Animals!.Include(animals => animals.Breeds).ToListAsync();
        }

        public async Task<Pet?> GetPetByIdAsync(int id)
        {
            return await _context.Pets!
                .Include(p => p.Breed)
                .ThenInclude(b => b!.Animal)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Breed?> GetBreedByIdAsync(int id)
        {
            return await _context.Breeds!
                .Include(breed => breed.Animal)
                .Include(breed => breed.Pets)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Animal?> GetAnimalsByIdAsync(int id)
        {
            return await _context.Animals!
                .Include(animals => animals.Breeds)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
