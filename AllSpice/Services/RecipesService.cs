using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;
        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }
        internal List<Recipe> Get()
        {
            return _repo.Get();
        }

        internal Recipe Get(int id)
        {
            Recipe found = _repo.Get(id);
            if (found == null)
            {
                throw new System.Exception("Invalid Id");
            }
            return found;
        }

        internal Recipe Create(Recipe newRecipe)
        {
            return _repo.Create(newRecipe);
        }

        internal void Remove(int id, string userId)
        {
            Recipe recipe = Get(id);
            if (recipe.CreatorId != userId)
            {
                throw new System.Exception("You are not allowed to remove this.");
            }
            _repo.Remove(id);
        }

    }
}