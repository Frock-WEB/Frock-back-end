namespace Frock_backend.routes.Domain.Model.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int RouteId { get; set; } // Foreign key to Route
        public DateTime StartTime { get; set; } // Start time of the schedule
        public DateTime EndTime { get; set; } // End time of the schedule
        public string DayOfWeek { get; set; } // Day of the week (e.g., "Monday", "Tuesday")
        public Schedule(int routeId, DateTime startTime, DateTime endTime, string dayOfWeek)
        {
            RouteId = routeId;
            StartTime = startTime;
            EndTime = endTime;
            DayOfWeek = dayOfWeek;
        }
    }
}
