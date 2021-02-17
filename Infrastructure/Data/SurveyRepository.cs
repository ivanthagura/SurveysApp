using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}