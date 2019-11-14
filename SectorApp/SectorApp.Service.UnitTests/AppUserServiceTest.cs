using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using NUnit.Framework;
using SectorApp.DataAccess.Models;
using SectorApp.Repository;
using SectorApp.Repository.Infrastructure;
using SectorApp.Service.Models;

namespace SectorApp.Service.UnitTests
{
    [TestFixture]
    public class AppUserServiceTest
    {
        private Mock<IAppUserRepository> _appUserRepository;
        private Mock<IUserSectorsRepository> _appUserRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private AppUserService _appUserService;
        private DbContextOptions _contextOptions;
        private DbContextMock<SectorAppContext> _contextMock;

        [SetUp]
        public void Setup()
        {
            _contextOptions = new DbContextOptionsBuilder<SectorAppContext>().Options;
            _contextMock = new DbContextMock<SectorAppContext>(_contextOptions);
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _appUserRepository = new Mock<IAppUserRepository>();
            _appUserRepositoryMock = new Mock<IUserSectorsRepository>();

            _appUserService = new AppUserService(_unitOfWorkMock.Object,_appUserRepository.Object, _appUserRepositoryMock.Object);
        }

        [Test]
        public void SaveOrUpdate_Create()
        {
            _contextMock.SetupGet(x => x.Database).Returns(new DatabaseFacade(_contextMock.Object));
            //_contextMock.Setup(x => x.Database.BeginTransaction()).Returns(null);

            Assert.Pass();
        }

        private UserSectorsModel GetUserSectorsModel()
        {
            return  new UserSectorsModel
            {
                Id = 0,
                TermsIsAccepted = true,
                Name = "Test"
            };
        }
    }
}