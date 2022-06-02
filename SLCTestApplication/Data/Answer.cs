using Microsoft.AspNetCore.Identity;

namespace SLCTestApplication.Data
{
    public class Answer
    {
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public string AnswerString { get; set; }
    }
}
