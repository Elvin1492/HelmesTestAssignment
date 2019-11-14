using Moq;
using NUnit.Framework;
using SectorApp.DataAccess.Models;
using SectorApp.Service;
using SectorApp.Service.Models;
using SectorApp.Web.UI.Controllers;
using System.Collections.Generic;

namespace Tests.Controllers
{
    [TestFixture]
    public class AppUserControllerTest
    {
        private Mock<IAppUserService> _appUserServiceMock;
        private AppUserController _appUserController;

        [SetUp]
        public void Setup()
        {
            _appUserServiceMock = new Mock<IAppUserService>();
            _appUserController = new AppUserController(_appUserServiceMock.Object);
        }

        [Test]
        public void Create_ModelStateIsInValid_ThrowInvalidOperationException()
        {
            _appUserController.ModelState.AddModelError("R", "R");
            Assert.Throws<System.InvalidOperationException>(() => _appUserController.Create(GetUserSectorsModel()));
        }

        [Test]
        public void Create_ShouldReturnCreatedAppUser()
        {
            var model = GetUserSectorsModel();
            _appUserServiceMock.Setup(x => x.SaveOrUpdate(model)).Returns(new AppUser
            {
                Id = 1,
                Name = "test",
                UsersSectors = null,
                TermsIsAccepted = true
            });

            var result = _appUserController.Create(model);

            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("test"));
            Assert.That(result.TermsIsAccepted, Is.EqualTo(true));
        }

        [Test]
        public void Get_ListOfAppUsers()
        {
            _appUserServiceMock.Setup(x => x.Get()).Returns(GetListAppUser());

            var result = _appUserController.Get();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        private UserSectorsModel GetUserSectorsModel()
        {
            return new UserSectorsModel
            {
                Id = 0,
                Name = "test",
                Sectors = null,
                TermsIsAccepted = true
            };
        }

        private IEnumerable<AppUser> GetListAppUser()
        {
            return new[]
            {
                new AppUser
                {
                    
                },
                new AppUser
                {

                }
            };
        }
    }
}