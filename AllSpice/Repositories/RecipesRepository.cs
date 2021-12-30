using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;
        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Recipe> Get()
        {
            string sql = "SELECT * FROM recipes;";
            return _db.Query<Recipe>(sql).ToList();
        }
        internal Recipe Create(Recipe newRecipe)
        {
            string sql = @"INSERT INTO recipes(name, creatorId)
            VALUES (@Name, @CreatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newRecipe);
            newRecipe.Id = id;
            return newRecipe;
        }
        internal Recipe Get(int id)
        {
            string sql = "SELECT * FROM recipes WHERE id = @id;";
            return _db.QueryFirstOrDefault<Recipe>(sql, new { id });
        }

        internal void Remove(int id)
        {
            string sql = "DELETE FROM recipes WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}