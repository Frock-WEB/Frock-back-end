using Frock_backend.routes.Domain.Model.Commands;
using Frock_backend.routes.REST.Resources;
using Frock_backend.routes.Domain.Model.Entities;
namespace Frock_backend.routes.REST.Transform
{
    public class CreateFullRouteCommandFromResponse
    {
        public static CreateFullRouteCommand toCommandFromResource(CreateFullRouteResource resource) =>
            new CreateFullRouteCommand(
                resource.Price,
                resource.Duration,
                resource.Frequency,
                resource.StopsIds,
                resource.Schedules.Select(schedule => new Schedule(
                    schedule.StartTime,
                    schedule.EndTime,
                    schedule.DayOfWeek,
                    schedule.Enabled
                )).ToList()
            );
    }
}
