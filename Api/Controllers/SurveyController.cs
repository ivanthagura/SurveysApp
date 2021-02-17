using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyRepository _surveryRepo;

        public SurveyController(ISurveyRepository surveryRepo)
        {
            _surveryRepo = surveryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await _surveryRepo.GetSurveys();
            return Ok(surveys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurvey(int id)
        {
            var survey = await _surveryRepo.GetSurvey(id);
            if (survey == null)
            {
                return BadRequest();
            }

            return Ok(survey);
        }
    }
}