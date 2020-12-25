using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Northwind.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<NorthwindController> _logger;
        private readonly NorthwindDbContext _context;

        public CustomersController(ILogger<NorthwindController> logger, NorthwindDbContext context)
        {
            _logger = logger;
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<object>> Get([FromQuery] AbpBaseFilter filter)
        {
            // IEnumerable<Customer>
            var query = _context.Customers.AsQueryable();
            return new
            {
                totalCount = (filter.RequestCount != false) ? ((int?)await query.CountAsync()) : null,
                items = await _context.Customers.Skip(filter.SkipCount).Take(filter.MaxResultCount).AsNoTracking().ToArrayAsync()
            };
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get([FromRoute] int id)
        {
            return await _context.Customers.FindAsync(id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Update(Customer item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
        [HttpPost()]
        public async Task<ActionResult<Customer>> Craete(Customer item)
        {
            _context.Customers.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete([FromRoute] int id)
        {
            var r = await _context.Customers.FindAsync(id);
            _context.Remove(r);
            await _context.SaveChangesAsync();
            return r;
        }
    }
}
