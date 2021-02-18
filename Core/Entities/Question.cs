using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Question : BaseEntity
    {
        public string CreatedBy { get; set; }
        public string CreatedDateTime { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public SurveyType SurveyType { get; set; }
        public int SurveyTypeId { get; set; }
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}