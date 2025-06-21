using Frock_backend.routes.Domain.Model.Entities;

namespace Frock_backend.routes.Domain.Model.Commands
{
    public record CreateFullRouteCommand(
        int Price,
        int Duration,
        int Frequency,
        List<int> StopsIds,
        List<Schedule> Schedules
    );
}
