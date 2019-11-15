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
        public ISectorRepository SectorRepository { get; }

        public SectorService(IUnitOfWork unitOfWork, ISectorRepository repository) : base(unitOfWork, repository)
        {
            SectorRepository = repository;
        }
    }
}