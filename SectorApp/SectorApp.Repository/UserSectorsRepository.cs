using SectorApp.DataAccess.Models;

namespace SectorApp.Repository
{
    public interface IUserSectorsRepository:IRepository<UsersSector>
    {

    }
    public class UserSectorsRepository : Repository<UsersSector>, IUserSectorsRepository
    {
        public UserSectorsRepository(SectorAppContext sectorAppContext) : base(sectorAppContext)
        {
        }
    }
}