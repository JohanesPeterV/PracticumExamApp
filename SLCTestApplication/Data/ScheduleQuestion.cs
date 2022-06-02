namespace SLCTestApplication.Data
{
    public class ScheduleQuestion
    {

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule{ get; set; }
    }
}
