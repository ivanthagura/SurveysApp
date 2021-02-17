using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Survey : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}