using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
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

        public AppUser SaveOrUpdate(UserSectorsModel userSectorsModel)
        {
            using (var tran = UnitOfWork.Context.Database.BeginTransaction())
            {
                var id = 0;
                if (userSectorsModel.IsNew)
                {
                    var user = _appUserRepository.Add(new AppUser() { Name = userSectorsModel.Name, TermsIsAccepted = userSectorsModel.TermsIsAccepted });

                    foreach (var sector in userSectorsModel.Sectors)
                    {
                        _userSectorsRepository.Add(new UsersSector()
                        {
                            SectorId = sector.Id,
                            UserId = user.Id
                        });
                    }

                    id = user.Id;
                }
                else
                {
                    _appUserRepository.Update(new AppUser()
                    {
                        Id = userSectorsModel.Id,
                        Name = userSectorsModel.Name,
                        TermsIsAccepted = true,
                        UsersSectors = null
                    });

                    _userSectorsRepository.DeleteWhere(x => x.UserId == userSectorsModel.Id);

                    foreach (var sector in userSectorsModel.Sectors)
                    {
                        _userSectorsRepository.Add(new UsersSector()
                        {
                            SectorId = sector.Id,
                            UserId = userSectorsModel.Id
                        });
                    }

                    id = userSectorsModel.Id;
                }
                tran.Commit();
                var result = _appUserRepository.Get(id);
                return result;
            }

        }
    }
}