using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Enitites.Breeds
{
    public record Breeds : BaseEntity
    {
        public string BreedCollectionName { get; init; } = "All Breeds";
        public IEnumerable<BreedType> BreedTypesCollection = new List<BreedType>();

        // public BirdBreeds BirdBreeds { get; init; }
        // public int BirdBreedsId { get; set; }

        // public CatBreeds CatBreeds { get; init; }
        // public int CatBreedsId { get; init; }

        // public DogBreeds DogBreeds { get; init; }
        // public int DobBreedsId { get; init; }

        // public FishBreeds FishBreeds { get; init; }
        // public int FishBreedsId { get; init; }
    }
}
