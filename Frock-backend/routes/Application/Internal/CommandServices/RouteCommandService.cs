using Frock_backend.routes.Domain.Model.Aggregates;
using Frock_backend.routes.Domain.Model.Commands;
using Frock_backend.routes.Domain.Repository;
using Frock_backend.routes.Domain.Service;
using Frock_backend.shared.Domain.Repositories;
using Frock_backend.shared.Infrastructure.Persistences.EFC.Repositories;
using Frock_backend.stops.Domain.Model.Aggregates;
using Frock_backend.stops.Domain.Model.Commands;
using Frock_backend.stops.Domain.Repositories;
using Frock_backend.stops.Infrastructure.Repositories;

namespace Frock_backend.routes.Application.Internal.CommandServices
{
    public class RouteCommandService(IRouteRepository routeRepository, IUnitOfWork unitOfWork):IRouteCommandService
    {
        public async Task<RouteAggregate?> Handle(CreateFullRouteCommand command)
        {

            var newRoute = new RouteAggregate(command);
            try
            {
                await routeRepository.AddAsync(newRoute);
                await unitOfWork.CompleteAsync();
                return newRoute;
            }
            catch (Exception e)
            {
                // logger?.LogError(e, "Error creating stop with name {StopName} for locality {LocalityId}.", command.Name, command.FkIdLocality);
                return null; // Signal failure to the controller
            }
        }
    }
}
