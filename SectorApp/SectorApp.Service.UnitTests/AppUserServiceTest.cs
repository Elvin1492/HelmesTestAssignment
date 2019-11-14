using System;
using System.Collections.Generic;
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
        private Mock<IAppUserRepository> _appUserRepositoryMock;
        private Mock<IUserSectorsRepository> _userSectorsRepository;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private AppUserService _appUserService;
        private SectorAppContext _sectorAppContext;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _appUserRepositoryMock = new Mock<IAppUserRepository>();
            _userSectorsRepository = new Mock<IUserSectorsRepository>();

            _appUserService = new AppUserService(_unitOfWorkMock.Object,_appUserRepositoryMock.Object, _userSectorsRepository.Object);
            var optionsBuilder = new DbContextOptionsBuilder<SectorAppContext>();
            optionsBuilder.UseSqlServer("Server=MAMMADOVE10;Database=SectorApp;Trusted_Connection=True;");
            _sectorAppContext = new SectorAppContext(optionsBuilder.Options);
        }

        [Test]
        public void SaveOrUpdate_IsNew_Create()
        {
            var model = GetAppUser();
            _unitOfWorkMock.SetupGet(x => x.Context).Returns(_sectorAppContext);

            _appUserRepositoryMock.Setup(x => x.Add(It.IsAny<AppUser>())).Returns(model);
            _appUserRepositoryMock.Setup(x => x.Get(1)).Returns(model);

            var result = _appUserService.SaveOrUpdate(GetUserSectorsModel());


            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void SaveOrUpdate_IsNotNew_Update()
        {
            var appUser = GetAppUser();
            _unitOfWorkMock.SetupGet(x => x.Context).Returns(_sectorAppContext);

            _appUserRepositoryMock.Setup(x => x.Update(It.IsAny<AppUser>())).Returns(appUser);
            _appUserRepositoryMock.Setup(x => x.Get(1)).Returns(appUser);

            var model = GetUserSectorsModel();
            model.Id = 1;
            var result = _appUserService.SaveOrUpdate(model);


            Assert.That(result.Id, Is.EqualTo(1));
        }

        private UserSectorsModel GetUserSectorsModel()
        {
            return  new UserSectorsModel
            {
                Id = 0,
                TermsIsAccepted = true,
                Name = "Test",
                Sectors = new List<Sector>()
            };
        }

        private AppUser GetAppUser()
        {
            return new AppUser
            {
                Id = 1,
                TermsIsAccepted = true,
                Name = "Test"
            };
        }
    }
}