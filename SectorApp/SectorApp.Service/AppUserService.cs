using SectorApp.DataAccess.Models;
using SectorApp.Repository;
using SectorApp.Repository.Infrastructure;
using SectorApp.Service.Models;

namespace SectorApp.Service
{
    public interface IAppUserService : IServiceBase<AppUser>
    {
        AppUser SaveOrUpdate(UserSectorsModel userSectors);
    }

    public class AppUserService : ServiceBase<AppUser>, IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IUserSectorsRepository _userSectorsRepository;

        public AppUserService(IUnitOfWork unitOfWork, IAppUserRepository repository, IUserSectorsRepository userSectorsRepository) : base(unitOfWork, repository)
        {
            _appUserRepository = repository;
            _userSectorsRepository = userSectorsRepository;
        }

        public AppUser SaveOrUpdate(UserSectorsModel userSectors)
        {
            using (var tran = UnitOfWork.Context.Database.BeginTransaction())
            {
                if (userSectors.IsNew)
                {
                    var user = _appUserRepository.Add(new AppUser() { Name = userSectors.Name, TermsIsAccepted = userSectors.TermsIsAccepted });

                    foreach (var sector in userSectors.Sectors)
                    {
                        _userSectorsRepository.Add(new UsersSector()
                        {
                            SectorId = sector.Id,
                            UserId = user.Id
                        });
                    }

                }
                else
                {
                    _appUserRepository.Update(new AppUser()
                    {
                        Id = userSectors.Id,
                        Name = userSectors.Name,
                        TermsIsAccepted = true
                    });

                    foreach (var sector in userSectors.Sectors)
                    {
                        _userSectorsRepository.Add(new UsersSector()
                        {
                            SectorId = sector.Id,
                            UserId = userSectors.Id
                        });
                    }
                }
                tran.Commit();
            }
            return null;
        }
    }
}