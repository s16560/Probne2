using Microsoft.AspNetCore.Mvc;
using Probne2.Services;

namespace Probne2.Controllers
{
    [Route("api/music-labels")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicDbService _dbService;

        public MusicController(IMusicDbService dbService) {
            _dbService = dbService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMusicLabel(int id) {
            var result = _dbService.GetMusicLabel(id);
            if (result == null)
                return NotFound("Label not found");

            return Ok(result);
        }

    }
}