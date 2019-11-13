using Microsoft.AspNetCore.Mvc;
using SectorApp.Service;
using SectorApp.Service.Models;

namespace SectorApp.Web.UI.Controllers
{
    [Route("api/[controller]")]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Create([FromBody] UserSectorsModel model)
        {
            _appUserService.SaveOrUpdate(model);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult Get()
        {
            var result = _appUserService.Get();
            return Json(result);
        }
    }
}