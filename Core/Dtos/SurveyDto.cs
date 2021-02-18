using System.Collections.Generic;

namespace Core.Dtos
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<QuestionDto> Questions { get; set; }
    }
}