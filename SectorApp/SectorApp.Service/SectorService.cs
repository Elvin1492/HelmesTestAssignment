using SectorApp.DataAccess.Models;
using SectorApp.Repository;
using SectorApp.Repository.Infrastructure;

namespace SectorApp.Service
{
    public interface ISectorService:IServiceBase<Sector>
    {
        
    }
    public class SectorService:ServiceBase<Sector>, ISectorService
    {
        private readonly ISectorRepository _sectorRepository;
        public SectorService(IUnitOfWork unitOfWork, ISectorRepository repository) : base(unitOfWork, repository)
        {
            _sectorRepository = repository;
        }
    }
}