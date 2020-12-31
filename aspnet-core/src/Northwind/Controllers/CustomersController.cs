using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using System.Globalization;
using System;
using System.Text.RegularExpressions;

namespace Northwind.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomersController : ControllerBase
    {
        public static string ToPascalCase(string original)
        {

            Regex invalidCharsRgx = new Regex("[^_a-zA-Z0-9]");
            Regex whiteSpace = new Regex(@"(?<=\s)");
            Regex startsWithLowerCaseChar = new Regex("^[a-z]");
            Regex firstCharFollowedByUpperCasesOnly = new Regex("(?<=[A-Z])[A-Z0-9]+$");
            Regex lowerCaseNextToNumber = new Regex("(?<=[0-9])[a-z]");
            Regex upperCaseInside = new Regex("(?<=[A-Z])[A-Z]+?((?=[A-Z][a-z])|(?=[0-9]))");

            // replace white spaces with undescore, then replace all invalid chars with empty string
            var pascalCase = invalidCharsRgx.Replace(whiteSpace.Replace(original, "_"), string.Empty)
                // split by underscores
                .Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                // set first letter to uppercase
                .Select(w => startsWithLowerCaseChar.Replace(w, m => m.Value.ToUpper()))
                // replace second and all following upper case letters to lower if there is no next lower (ABC -> Abc)
                .Select(w => firstCharFollowedByUpperCasesOnly.Replace(w, m => m.Value.ToLower()))
                // set upper case the first lower case following a number (Ab9cd -> Ab9Cd)
                .Select(w => lowerCaseNextToNumber.Replace(w, m => m.Value.ToUpper()))
                // lower second and next upper case letters except the last if it follows by any lower (ABcDEf -> AbcDef)
                .Select(w => upperCaseInside.Replace(w, m => m.Value.ToLower()));

            return string.Concat(pascalCase);
        }
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
            if (!string.IsNullOrEmpty(filter.Sort))
            {


                query = query.OrderBy(filter.Sort);
            }
            return new
            {
                totalCount = (filter.RequestCount != false) ? ((int?)await query.CountAsync()) : null,
                items = await query.Skip(filter.SkipCount).Take(filter.MaxResultCount).AsNoTracking().ToArrayAsync()
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
