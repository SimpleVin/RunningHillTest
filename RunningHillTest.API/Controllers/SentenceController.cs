using MediatR;
using Microsoft.AspNetCore.Mvc;
using RunningHillTest.Application.Interfaces;

namespace RunningHillTest.API.Controllers
{
    public class SentenceController : Controller
    {
        private readonly ISentenceService _sentenceService;
        private readonly ILogger<SentenceController> _logger;

        public SentenceController(ILogger<SentenceController> logger, ISentenceService sentenceService)
        {
            _logger = logger;
            _sentenceService = sentenceService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
