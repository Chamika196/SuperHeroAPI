using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroServices;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroServices = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            
            return await _superHeroServices.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult <SuperHero>> GetSingleHero(int id)
        {
            var result =await _superHeroServices.GetSingleHero(id);
            if (result is null)
            {
                return NotFound("Hero not Found");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result =await _superHeroServices.AddHero(hero);
            

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = await _superHeroServices.UpdateHero(id, request);
            if (result is null)
            {
                return NotFound("Hero not Found");
            }
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _superHeroServices.DeleteHero(id);
            if(result is null)
            {
                return NotFound("Hero not Found");
            }

            return Ok(result);
        }
    }
}
