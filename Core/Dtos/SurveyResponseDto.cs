using System.Collections.Generic;

namespace Core.Dtos
{
    public class SurveyResponseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int SurveyId { get; set; }
        public ICollection<SurveyResponseAnswerDto> Answers { get; set; }
    }
}