using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Core.Enitites.Breeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly ShelterContext _context;
        private readonly ILogger<ShelterRepository> _logger;

        public ShelterRepository(ShelterContext context, ILogger<ShelterRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Pet>> GetPets()
        {
            IEnumerable<Pet> pets = new List<Pet>();
            try
            {
                pets = await _context.Pets!
                    .Include(pet => pet.Breed)
                    .ThenInclude(x => x!.Animal)
                    .Include(pet => pet.Location)
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return pets;
        }

        public async Task<IEnumerable<Breed>> GetBreeds()
        {
            IEnumerable<Breed> breeds = new List<Breed>();
            try
            {
                breeds = await _context.Breeds!.ToListAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return breeds;
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            IEnumerable<Animal> animals = new List<Animal>();
            try
            {
                animals = await _context.Animals!.ToListAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return animals;
        }
    }
}
