namespace SLCTestApplication.Data
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ScheduleQuestion> ScheduleQuestions{ get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? GetStartTimeSpan()
        {
            if (StartTime == null) return null;
            return StartTime.Value.TimeOfDay;
        }
        public TimeSpan? GetEndTimeSpan()
        {
            if (EndTime == null) return null;
            return EndTime.Value.TimeOfDay;
        }
        public void SetStartTimeSpan(TimeSpan? startTimeSpan)
        {
            if (StartTime == null || startTimeSpan == null) return;
            StartTime = StartTime.Value.Date + startTimeSpan;
        }
        public void SetEndTimeSpan(TimeSpan? endTimeSpan)
        {
            if (EndTime == null || endTimeSpan == null) return;
            EndTime= EndTime.Value.Date + endTimeSpan;
        }
        
    }
}
