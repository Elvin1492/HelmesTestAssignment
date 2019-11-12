using System.Text;
using SectorApp.DataAccess.Models;

namespace SectorApp.Repository
{
    public interface IAppUserRepository:IRepository<AppUser>
    {

    }

    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(SectorAppContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
