using MediatR;
using Microsoft.AspNetCore.Mvc;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Domain.Interfaces;

namespace RunningHillTest.API.Controllers
{
    [ApiController]
    [Route("api/wordType")]
    public class WordTypeController : Controller
    {
        private readonly IWordTypeService _wordTypeService;
        private readonly ILogger<WordTypeController> _logger;

        public WordTypeController(ILogger<WordTypeController> logger, IWordTypeService wordTypeService)
        {
            _logger = logger;
            _wordTypeService = wordTypeService;
        }


        [HttpGet("GetWordType/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWordType(int id)
        {
            var wordType = await _wordTypeService.GetWordType(id);

            return Ok(wordType);
        }

        [HttpGet("GetWordTypes")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWordTypes()
        {
            var wordTypes = await _wordTypeService.GetWordTypes();

            return Ok(wordTypes);
        }
    }
}
