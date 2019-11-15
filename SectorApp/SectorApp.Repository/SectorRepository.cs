using SectorApp.DataAccess.Models;

namespace SectorApp.Repository
{
    public interface ISectorRepository : IRepository<Sector>
    {

    }
    public class SectorRepository : Repository<Sector>, ISectorRepository
    {
        public SectorRepository(SectorAppContext sectorAppContext) : base(sectorAppContext)
        {
        }
    }
}