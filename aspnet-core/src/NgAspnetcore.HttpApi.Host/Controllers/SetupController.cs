using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NgAspnetcore.Models;

namespace NgAspnetcore.HttpApi.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SetupController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SetupController> _logger;

        public SetupController(ILogger<SetupController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/api/sutup")]
        public async void Setup([FromServices] ApplicationDbContext context, [FromServices] UserManager<ApplicationUser> userManager)
        {
            context.Database.Migrate();
            try
            {
                await userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = "admin",
                    Email = "admin@ngdz.dz",


                }, "1q2w3E*");
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, nameof(Setup));
            }
        }
    }
}
