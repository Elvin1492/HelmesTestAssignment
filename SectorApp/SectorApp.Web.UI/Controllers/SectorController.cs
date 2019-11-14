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
            List<Sector> list = new List<Sector>();
            CreateSequentialTree(tree.ToList(),list, 0);
            return list;
        }

        private void CreateSequentialTree(List<TreeItem<Sector>> treeItems, List<Sector> list, int deep = 0)
        {
            for (int i = 0; i < treeItems.Count(); i++)
            {
                treeItems[i].Item.Name = new string('\xa0', deep * 10) + treeItems[i].Item.Name;
                list.Add(treeItems[i].Item);
                CreateSequentialTree(treeItems[i].Children.ToList(),list, deep + 1);
            }
        }

    }
}