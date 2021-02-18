using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ISurveyRepository
    {
        Task<List<Survey>> GetSurveys();
        Task<Survey> GetSurvey(int id);
        Task<bool> AddSurveyResponse(Survey survey, SurveyResponseDto surveyResponse);
    }
}