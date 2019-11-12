using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SectorApp.DataAccess.Models;
using SectorApp.Service;

namespace SectorApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private SectorAppContext _sectorAppContext;
        private IAppUserService _appUserService;

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public SampleDataController(SectorAppContext sectorAppContext, IAppUserService appUserService)
        {
            _sectorAppContext = sectorAppContext;
            _appUserService = appUserService;
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public List<AppUser> GetSectors()
        {
            //var result = _sectorAppContext.AppUsers;
            var result = _appUserService.Get();
            return result.ToList();
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
