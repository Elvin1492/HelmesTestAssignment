using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SectorApp.DataAccess.Models;
using SectorApp.Service;
using SectorApp.Service.Models;

namespace SectorApp.Web.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost]
        [Route("[action]")]
        public AppUser Create([FromBody] UserSectorsModel model)
        {
            if (!ModelState.IsValid) throw new InvalidOperationException(
                "All fields are required");
            var result = _appUserService.SaveOrUpdate(model);
            return result;

        }

        [HttpGet]
        [Route("[action]")]
        public ICollection<AppUser> Get()
        {
            var result = _appUserService.Get();
            return result.ToList();
        }
    }
}