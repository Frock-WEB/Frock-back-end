using Frock_backend.routes.Domain.Model.Commands;
using Frock_backend.routes.Domain.Service;
using Frock_backend.routes.Domain.Model.Aggregates;

namespace Frock_backend.routes.Application.Internal.CommandServices
{
    public class RouteCommandService:IRouteCommandService
    {
        Task<RouteAggregate?> handle(CreateFullRouteCommand command)
        {
            var route = new RouteAggregate(command);

        }
    }
}
