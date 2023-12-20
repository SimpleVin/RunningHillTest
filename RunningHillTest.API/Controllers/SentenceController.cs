using MediatR;
using Microsoft.AspNetCore.Mvc;
using RunningHillTest.Application.Interfaces;
using RunningHillTest.Application.Models;
using RunningHillTest.Infrastructure.Persistance.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace RunningHillTest.API.Controllers
{
    [Route("api/sentence")]
    public class SentenceController : Controller
    {
        private readonly ISentenceService _sentenceService;
        private readonly ILogger<SentenceController> _logger;

        public SentenceController(ILogger<SentenceController> logger, ISentenceService sentenceService)
        {
            _logger = logger;
            _sentenceService = sentenceService;
        }
        [HttpPost("SaveSentence")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSentence([FromBody] SentenceDto saveSentence
            )
        {
            var result = await _sentenceService.SaveSentence(saveSentence);
            if (result)
                return Ok("Sentence created successfully");
            else
                return BadRequest("Sentence failed to save.");
        }

        [HttpGet("GetSentence/{id}")]
        [Produces("application/json")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(SentenceDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSentence(Guid id)
        {
            var result = await _sentenceService.GetSentence(id);

            return Ok(result);
        }


        [HttpGet("GetSentences")]
        [Produces("application/json")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(List<SentenceDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSentences()
        {
            var result = await _sentenceService.GetSentences();

            return Ok(result);
        }
    }
}
