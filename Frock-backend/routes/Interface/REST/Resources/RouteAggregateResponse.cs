
namespace Frock_backend.routes.Interface.REST.Resources
{
    public record RouteAggregateResponse
    (
        int id,
        int price,
        int frequency,
        int duration,
        List<StopResource> stops,
        List<ScheduleResource> schedules
    );
}
