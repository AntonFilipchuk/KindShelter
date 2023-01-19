using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;

namespace Infrastructure.Data
{
    public class ShelterContextRandomSeed
    {
        private ShelterContext _context;

        public ShelterContextRandomSeed(ShelterContext context)
        {
            _context = context;
        }

        private List<Adress> adresses = new();
        private List<Breed> breeds = new();
        private Random random = new Random();

        public void RandomSeed()
        {
            int numberToGenerate = 500;
            if (!_context.Animals.Any())
            {
                AddAnimals();
            }
            if (!_context.Cities.Any())
            {
                AddCities();
            }
            if (!_context.Breeds.Any())
            {
                AddBreeds();
            }
            if (!_context.Adresses.Any())
            {
                RandomAdresses(numberToGenerate);
            }
            if (!_context.Pets.Any())
            {
                RandomPets(numberToGenerate);
            }
        }

        private void AddAnimals()
        {
            Animals cats = new Animals()
            {
                Breeds = new List<Breed>(),
                CollectionName = "Cats",
                Id = 1
            };

            Animals dogs = new Animals()
            {
                Breeds = new List<Breed>(),
                CollectionName = "Dogs",
                Id = 2
            };

            _context.Animals.Add(cats);
            _context.Animals.Add(dogs);
            _context.SaveChanges();
        }

        private void AddCities()
        {
            City moscow = new City()
            {
                CityName = "Moscow",
                Id = 1,
                Adresses = new List<Adress>(),
            };
            City kazan = new City()
            {
                CityName = "Kazan",
                Id = 2,
                Adresses = new List<Adress>(),
            };

            _context.Cities.Add(moscow);
            _context.Cities.Add(kazan);
            _context.SaveChanges();
        }

        private void AddBreeds()
        {
            string[] chars = new string[]
            {
                "Cool",
                "Fat",
                "Funny",
                "Big",
                "Brave",
                "Lovely",
                "Scary",
                "Adorable"
            };

            for (int i = 1; i < chars.Count(); i++)
            {
                Breed catBreed = new Breed()
                {
                    Animals = _context.Animals.Single(a => a.Id == 1),
                    AnimalsId = 1,
                    BreedName = $"{chars[random.Next(chars.Count())]} Cat",
                    Id = i,
                    Pets = new List<Pet>()
                };
                _context.Breeds.Add(catBreed);
            }

            for (int i = chars.Count() + 1; i < chars.Count() * 2; i++)
            {
                Breed dogBreed = new Breed()
                {
                    Animals = _context.Animals.Single(a => a.Id == 2),
                    AnimalsId = 2,
                    BreedName = $"{chars[random.Next(chars.Count())]} Dog",
                    Id = i,
                    Pets = new List<Pet>()
                };
                _context.Breeds.Add(dogBreed);
            }
            _context.SaveChanges();
        }

        private void RandomAdresses(int numberToGenerate)
        {
            string[] streets = new string[]
            {
                "Lenina",
                "Baumana",
                "Furshatstkaya",
                "Oktabr'skaya",
                "Lesnoy Port",
                "Rabochiy Kvartal",
                "Recnhaya",
                "Pinerov",
                "Lubyanka",
                "Skobelevskaya",
                "Mira"
            };

            for (int i = 1; i < numberToGenerate; i++)
            {
                City randomCity = _context.Cities.ToList()[random.Next(_context.Cities.Count())];
                int randomCityId = randomCity.Id;
                Adress adress = new Adress()
                {
                    City = randomCity,
                    CityId = randomCityId,
                    Id = i,
                    FlatNumber = random.Next(200),
                    HouseNumber = random.Next(100),
                    Street = streets[random.Next(streets.Count())]
                };

                adresses.Add(adress);
                _context.Adresses.Add(adress);
            }

            _context.SaveChanges();
        }

        private void RandomPets(int numberToGenerate)
        {
            for (int i = 1; i < numberToGenerate; i++)
            {
                bool?[] ifVaccinated = new bool?[] { true, false, null };
                string[] genders = new string[] { "male", "female" };
                string[] colors = new string[]
                {
                    "white",
                    "black",
                    "orange",
                    "white",
                    "yellow",
                    "grey"
                };
                string[] names = new string[]
                {
                    "Moonshine",
                    "Jellybean",
                    "Charisma",
                    "Pogo",
                    "Miles",
                    "Munchkin",
                    "Cozmo",
                    "Snickers",
                    "Noodles",
                    "Kane",
                    "Bubba",
                    "Dewey",
                    "Casey",
                    "Sabrina",
                    "Mulligan",
                    "Mac",
                    "Jelly",
                    "Champ",
                    "Xena",
                    "Dutches",
                    "Wizard"
                };

                Adress randomAdress = adresses[i - 1];
                Breed randomBreed = _context.Breeds.ToList()[random.Next(_context.Breeds.Count())];

                Pet pet = new Pet()
                {
                    Name = names[random.Next(names.Count())],
                    Color = colors[random.Next(colors.Count())],
                    Age = random.Next(20),
                    PictureUrl = $"{Guid.NewGuid().ToString()}",
                    Adress = randomAdress,
                    AdressId = randomAdress.Id,
                    Breed = randomBreed,
                    BreedId = randomBreed.Id,
                    Gender = genders[random.Next(genders.Count())],
                    Id = i,
                    HasVaccines = ifVaccinated[random.Next(ifVaccinated.Count())],
                    Description = random.Next(Int32.MaxValue).ToString()
                };

                _context.Pets.Add(pet);
            }

            _context.SaveChanges();
        }
    }
}
