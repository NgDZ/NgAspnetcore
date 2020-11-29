using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Breeze.AspNetCore;
using Breeze.Persistence;
using Breeze.Persistence.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NgAspnetcore.Models;

namespace Northwind.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    [ApiExplorerSettings(GroupName = "Northwind")]
    public class NorthwindController : ControllerBase
    {
        private readonly ILogger<NorthwindController> _logger;
        private readonly EFPersistenceManager<NorthwindDbContext> PersistenceManager;

        public NorthwindController(ILogger<NorthwindController> logger, NorthwindDbContext context)
        {
            _logger = logger;
            Context = context;
            PersistenceManager = new EFPersistenceManager<NorthwindDbContext>(context);
        }

        public NorthwindDbContext Context { get; }

        private static string _Metadata;
        [HttpGet]
        [Route("metadata")]
        public string MetaData()
        {
            if (string.IsNullOrWhiteSpace(_Metadata)) _Metadata = this.PersistenceManager.Metadata();
            return _Metadata;
        }


        [HttpPost]
        [Route("SaveChanges")]
        public SaveResult SaveChanges([FromBody] JObject saveBundle)
        {
            return PersistenceManager.SaveChanges(saveBundle);
        }
        public class LookupsOptions
        {
            public bool? Customers { get; set; } = false;
        }
        [HttpGet]
        [Route("Lookups")]
        public object Lookups([FromQuery] LookupsOptions Params)
        {
            var ret = new
            {
                Customers = Context.Customers.AsNoTracking().ToArray(),
                Products = Context.Products.AsNoTracking().ToArray(),
                // Orders = Context.Orders.AsNoTracking().ToArray(),

            };
            return ret;
        }

        [HttpGet]
        [Route("SalesOrders")]
        [BreezeQueryFilter]
        public object SalesOrders()
        {
            return Context.SalesOrders.AsNoTracking();
        }

        [HttpGet]
        [Route("Customers")]
        [BreezeQueryFilter]
        public object Customers()
        {

            return Context.Customers.AsNoTracking();
        }
    }
}
