using Frock_backend.routes.Domain.Model.Aggregates;
using Frock_backend.stops.Domain.Model.Aggregates;
namespace Frock_backend.routes.Domain.Model.ValueObjects
{
    public class RoutesStops
    {
        public int FkStopId { get; set; } // Foreign key to Route
        public int FKRouteId { get; set; } // Foreign key to Stop
        public RouteAggregate Route { get; set; } // Navigation property to Route
        public Stop Stop { get; set; } // Navigation property to Stop
        public RoutesStops(int FkStopId)
        {
            this.FkStopId = FkStopId;
        }
    }
}
