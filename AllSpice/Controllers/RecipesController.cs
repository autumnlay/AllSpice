
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _rs;
        private readonly AccountService _acctService;

        public RecipesController(RecipesService rs)
        {
            _rs = rs;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> Get()
        {
            try
            {
                var recipe = _rs.Get();
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> Get(int id)
        {
            try
            {
                var recipe = _rs.Get(id);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpGet("{id}/accounts")]
        // public ActionResult<IEnumerable<AccountRecipeViewModel>> GetAccounts(int id)
        // {
        //     try
        //     {
        //         List<AccountRecipeViewModel> accounts = _acctService.GetByRecipeId(id);
        //         return Ok(accounts);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        [HttpPost]
        // [Authorize]
        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newRecipe.CreatorId = userInfo?.Id;
                Recipe recipe = _rs.Create(newRecipe);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        // [Authorize]
        public async Task<ActionResult<Recipe>> Remove(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _rs.Remove(id, userInfo.Id);
                return Ok("Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}