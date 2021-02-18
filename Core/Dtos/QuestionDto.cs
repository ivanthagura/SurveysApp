using System.Collections.Generic;

namespace Core.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDateTime { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int SurveyTypeId { get; set; }
        public ICollection<OptionDto> Options { get; set; }
    }
}