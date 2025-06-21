namespace Frock_backend.routes.Domain.Model.ValueObjects
{
    public class RoutesStops
    {
        public int FkStopId { get; set; } // Foreign key to Route
        public RoutesStops(int FkStopId)
        {
            this.FkStopId = FkStopId;
        }
    }
}
