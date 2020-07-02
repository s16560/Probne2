
using Microsoft.AspNetCore.Mvc;
using Probne2.Exceptions;
using Probne2.Services;

namespace Probne2.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly IMusicDbService _dbService;

        public MusiciansController(IMusicDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveMusician(int id)
        {
            try {
                _dbService.RemoveMusician(id);
                return NoContent();
            }
            catch (MusicianDoesNotExistException e) {
                return NotFound(e.Message);
            }
        }
    }
}