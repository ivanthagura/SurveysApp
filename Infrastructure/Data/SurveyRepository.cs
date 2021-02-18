using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyContext _context;

        public SurveyRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<Survey> GetSurvey(int id)
        {
            var survey = await _context.Surveys.Where(s => s.Id == id)
                            .Include(s => s.Questions).ThenInclude(q => q.Options)
                            .FirstOrDefaultAsync();
            return survey;
        }

        public async Task<List<Survey>> GetSurveys()
        {
            var surveys = await _context.Surveys.ToListAsync();
            return surveys;
        }

        public async Task<bool> AddSurveyResponse(Survey survey, SurveyResponseDto surveyResponse)
        {
            var answers = new List<Answer>();

            foreach (var question in survey.Questions)
            {
                var responseAnswer = surveyResponse.Answers.FirstOrDefault(a => a.QuestionId == question.Id);
                if (responseAnswer != null)
                {
                    var answer = new Answer
                    {
                        Question = question,
                        QuestionId = question.Id,
                        QuestionAnswer = responseAnswer.QuestionAnswer
                    };

                    answers.Add(answer);
                }
            }

            var response = new Response
            {
                Email = surveyResponse.Email,
                Name = surveyResponse.Name,
                Survey = survey,
                SurveyId = survey.Id,
                Answers = answers
            };

            _context.SurveyResponses.Add(response);
            var saved = await _context.SaveChangesAsync();

            return saved > 0;
        }
    }
}