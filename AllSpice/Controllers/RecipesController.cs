
using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _ss;
        private readonly AccountService _acctService;
    }

    // public RecipesController(RecipesService ss, AccountService acctService)
    // {
    //     _ss = ss;
    //     _acctService = acctService;
    // }
}