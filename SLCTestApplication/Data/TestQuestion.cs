namespace SLCTestApplication.Data
{
    public class TestQuestion
    {

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}
