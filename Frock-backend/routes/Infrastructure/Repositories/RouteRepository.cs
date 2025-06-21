using Frock_backend.routes.Domain.Model.Aggregates;
using Frock_backend.routes.Domain.Repository;
using Frock_backend.shared.Domain.Repositories;
using Frock_backend.shared.Infrastructure.Persistences.EFC.Configuration;
using Frock_backend.shared.Infrastructure.Persistences.EFC.Repositories;
using Frock_backend.stops.Domain.Model.Aggregates;
using Frock_backend.stops.Domain.Repositories;

namespace Frock_backend.routes.Infrastructure.Repositories
{
    public class RouteRepository(AppDbContext context) : BaseRepository<RouteAggregate>(context), IRouteRepository
    {
        
    }
}
