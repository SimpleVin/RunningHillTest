using MediatR;
using Microsoft.AspNetCore.Mvc;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Application.Mappers;
using RunningHillTest.Application.Models;
using RunningHillTest.Domain.Interfaces;
using RunningHillTest.Infrastructure.Persistance.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace RunningHillTest.API.Controllers
{
    [ApiController]
    [Route("api/word")]
    public class WordController : ControllerBase
    {

        private readonly IWordService _wordService;
        private readonly ILogger<WordController> _logger;

        public WordController(ILogger<WordController> logger, IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;
        }

        [HttpPost("SaveWord")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateWord([FromBody] WordDto saveWord)
        {
            var result = await _wordService.SaveWord(saveWord);
            if (result)
                return Ok("Word created successfully");
            else
                return BadRequest("Word failed to save.");
        }

        [HttpGet("GetWord/{id}")]
        [Produces("application/json")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(WordDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWord(Guid id)
        {
            var result = await _wordService.GetWord(id);

            return Ok(result);
        }


        [HttpGet("GetWordsByWordType/{id}")]
        [Produces("application/json")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(List<WordDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWordsByWordTypeId(int id)
        {
            var result = await _wordService.GetWordsByWordTypeId(id);

            return Ok(result);
        }

        [HttpGet("GetWords")]
        [Produces("application/json")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(List<WordDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWords()
        {
            var result = await _wordService.GetAllWords();

            return Ok(result);
        }


    }
}