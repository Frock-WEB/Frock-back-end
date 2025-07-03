using Frock_backend.shared.Domain.Repositories;
using Frock_backend.stops.Domain.Model.Aggregates;

namespace Frock_backend.stops.Domain.Repositories
{
    public interface IStopRepository : IBaseRepository<Stop>
    {
        Task<IEnumerable<Stop>> FindByFkIdCompanyAsync(int fkIdCompany);
        Task<IEnumerable<Stop>> FindByFkIdDistrictAsync(string fkIdDistrict);
        Task<Stop?> FindByNameAndFkIdDistrictAsync(string name, string fkIdDistrict);
    }
}
