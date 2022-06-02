namespace SLCTestApplication.Data
{
    public class QuestionAnswerAggregate
    {
        public Answer Answer { get; set; }
        public Question Question { get; set; }
        public QuestionAnswerAggregate(Answer answer, Question question)
        {
            Answer = answer;
            Question = question;    
        }
    }
}
