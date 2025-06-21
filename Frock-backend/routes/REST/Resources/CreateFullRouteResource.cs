namespace Frock_backend.routes.REST.Resources
{
    public record CreateFullRouteResource
    (
        int Frequency,
        int Price,
        int Duration,
        List<int> StopsIds, // List of stop IDs that this route will include
        List<CreateScheduleResource> Schedules // List of schedules for the route    
    );
}
