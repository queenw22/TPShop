using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data;
using Core.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ShopContext _context;
        public ServiceController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetServices()
        {
            var services = await _context.Services.ToListAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            return await _context.Services.FindAsync(id);
        }
    }
}