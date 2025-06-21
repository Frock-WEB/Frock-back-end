namespace Frock_backend.routes.REST.Resources
{
    public record CreateScheduleResource(
        string DayOfWeek,
        DateTime StartTime,
        DateTime EndTime
        );
}
