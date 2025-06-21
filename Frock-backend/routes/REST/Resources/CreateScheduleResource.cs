namespace Frock_backend.routes.REST.Resources
{
    public record CreateScheduleResource(
        string DayOfWeek,
        string StartTime,
        string EndTime,
        bool Enabled
        );
}
