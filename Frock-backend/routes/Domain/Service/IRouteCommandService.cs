using Frock_backend.routes.Domain.Model.Commands;
using Frock_backend.shared.Domain.Repositories;

namespace Frock_backend.routes.Domain.Service
{
    public interface IRouteCommandService
    {
        Task<Route?> Handle(CreateFullRouteCommand command);
    }
}
