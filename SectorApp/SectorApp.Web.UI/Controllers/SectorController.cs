using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SectorApp.DataAccess.Models;
using SectorApp.Service;
using SectorApp.Web.UI.Infrastructure.Helpers;

namespace SectorApp.Web.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet("[action]")]
        public ICollection<Sector> GetSectors()
        {
            var result = _sectorService.Get();
            var tree = result.ToList().GenerateTree(x => x.Id, x => x.ParentId);
            var list = new List<Sector>();
            GenericHelpers.CreateSequentialTree(tree.ToList(),list);
            return list;
        }
    }
}