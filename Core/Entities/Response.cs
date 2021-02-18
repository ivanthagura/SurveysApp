using System.Collections.Generic;

namespace Core.Entities
{
    public class Response : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}