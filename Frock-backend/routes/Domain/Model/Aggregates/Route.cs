using Frock_backend.routes.Domain.Model.Commands;
using Frock_backend.routes.Domain.Model.Entities;
using Frock_backend.routes.Domain.Model.ValueObjects;
using Frock_backend.stops.Domain.Model.Aggregates;

namespace Frock_backend.routes.Domain.Model.Aggregates
{
    public class RouteAggregate
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; } // in minutes
        public int Frequency { get; set; } // in minutes
        public  List<Schedule> Schedules = new();
        public List<RoutesStops> _stops = new();
        public IReadOnlyCollection<RoutesStops> Stops => _stops;
        public RouteAggregate(double Price, int Duration, int Frequency)
        {
            this.Price = Price;
            this.Duration = Duration;
            this.Frequency = Frequency;
        }
        // 3) Método para añadir un horario
        public void AddSchedule(DateTime start, DateTime end, string dayOfWeek)
        {
            Schedules.Add(new Schedule(this.Id, start, end, dayOfWeek));
        }

        // Renamed the method to avoid conflict with the class name
        public RouteAggregate(CreateFullRouteCommand cm)
        {
            this.Price = cm.Price;
            this.Duration = cm.Duration;
            this.Frequency = cm.Frequency;
            foreach (var stopId in cm.StopsIds)
            {
                // Assuming RoutesStops is a value object that holds the stop ID
                var routeStop = new RoutesStops(stopId);
                // Here you would typically add this to a collection of stops in the Route aggregate
                // For example: this.Stops.Add(routeStop);
            }
            foreach (var schedule in cm.Schedules)
            {
                this.AddSchedule(schedule.StartTime, schedule.EndTime, schedule.DayOfWeek);
            }
        }
    }
}
