using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Services.FavoriteService;

namespace Travelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }
        [HttpGet]
        public async Task<IActionResult> Recomended([FromHeader]string Token)
        {
            var result = await favoriteService.ReccomendedByFavorite(Token);
            return Ok(result);
        }
    }
}
