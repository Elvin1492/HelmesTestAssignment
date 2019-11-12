using SectorApp.DataAccess.Models;
using SectorApp.Repository;
using SectorApp.Repository.Infrastructure;

namespace SectorApp.Service
{
    public interface IAppUserService : IServiceBase<AppUser>
    {

    }

    public class AppUserService : ServiceBase<AppUser>, IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        public AppUserService(IUnitOfWork unitOfWork, IAppUserRepository repository) : base(unitOfWork, repository)
        {
            _appUserRepository = repository;
        }
    }
}