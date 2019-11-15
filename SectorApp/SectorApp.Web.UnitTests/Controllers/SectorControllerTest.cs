using Moq;
using NUnit.Framework;
using SectorApp.DataAccess.Models;
using SectorApp.Service;
using SectorApp.Web.UI.Controllers;

namespace SectorApp.Web.UnitTests.Controllers
{
    [TestFixture]
    public class SectorControllerTest
    {
        private Mock<ISectorService> _sectorServiceMock;

        private SectorController _sectorController;

        [SetUp]
        public void Setup()
        {
            _sectorServiceMock = new Mock<ISectorService>();

            _sectorController = new SectorController(_sectorServiceMock.Object);
        }

        [Test]
        public void Get_ListOfSectors()
        {
            _sectorServiceMock.Setup(x => x.Get()).Returns(new[]
            {
                new Sector
                {
                    Id = 1,
                    Name ="Test",
                    ParentId = null,
                },
                new Sector
                {
                    Id = 2,
                    Name ="Tes2",
                    ParentId = 1
                }
            });

            var result = _sectorController.GetSectors();
            Assert.That(result.Count, Is.EqualTo(2));
        }
    }
}
