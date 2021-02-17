using System.Collections.Generic;
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
        public async Task<List<Survey>> GetSurveysAsync()
        {
            return await _context.Surveys.ToListAsync();
        }
    }
}