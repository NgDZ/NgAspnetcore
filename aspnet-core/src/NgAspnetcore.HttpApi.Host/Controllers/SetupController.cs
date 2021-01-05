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
    // [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Config")]
    [Route("[controller]/[action]")]
    public class SetupController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        [HttpGet()]
        public virtual async Task ValidateAsync(string userName, string password,
                [FromServices] SignInManager<ApplicationUser> _signInManager,
                [FromServices] UserManager<ApplicationUser> _userManager)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                Console.WriteLine(password);
                var result = await _signInManager.CheckPasswordSignInAsync(user, password, true);

                var resetPassResult = _userManager.PasswordHasher.HashPassword(user, user.UserName);
                System.Console.WriteLine(resetPassResult);
                resetPassResult = _userManager.PasswordHasher.HashPassword(user, user.UserName);
                System.Console.WriteLine(resetPassResult);
                if (result.Succeeded)
                {
                    // var sub = await _userManager.GeApplicationUserIdAsync(user);
                }
            }
        }
        private readonly ILogger<SetupController> _logger;

        public SetupController(ILogger<SetupController> logger)
        {
            _logger = logger;
        }
        [HttpGet("GeRandomResults")]
        public IEnumerable<object> GeRandomResults()
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

        [HttpGet()]
        public async Task<object> Setup([FromServices] ApplicationDbContext context, [FromServices] UserManager<ApplicationUser> userManager)
        {
            await context.Database.MigrateAsync();

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
            context.SaveChanges();
            return await context.Users.ToListAsync();
        }
    }
}
