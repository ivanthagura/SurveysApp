namespace Core.Entities
{
    public class Answer : BaseEntity
    {
        public string QuestionAnswer { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}