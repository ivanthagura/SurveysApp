using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyRepository _surveryRepo;
        private readonly IMapper _mapper;

        public SurveyController(ISurveyRepository surveryRepo, IMapper mapper)
        {
            _surveryRepo = surveryRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await _surveryRepo.GetSurveys();
            var surveysDto = _mapper.Map<List<SurveyDto>>(surveys);

            return Ok(surveysDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurvey(int id)
        {
            var survey = await _surveryRepo.GetSurvey(id);
            if (survey == null)
            {
                return BadRequest();
            }

            var surveyDto = _mapper.Map<SurveyDto>(survey);
            return Ok(surveyDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddSurveyResponse(SurveyResponseDto surveyResponse)
        {
            if (surveyResponse.SurveyId == 0)
            {
                ModelState.AddModelError("Error", "No survey id");
                return BadRequest(ModelState);
            }

            var survey = await _surveryRepo.GetSurvey(surveyResponse.SurveyId);
            if (survey == null)
            {
                ModelState.AddModelError("Error", "Invalid survey id");
                return BadRequest(ModelState);
            }

            if (surveyResponse.Answers.Count == 0)
            {
                ModelState.AddModelError("Error", "No answers in survey response");
                return BadRequest(ModelState);
            }

            var responseSaved = await _surveryRepo.AddSurveyResponse(survey, surveyResponse);
            if (!responseSaved)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Ok();
        }
    }
}