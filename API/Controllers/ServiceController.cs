using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data;
using Core.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepo _repo;

        public ServiceController(IServiceRepo repo)
        {
            _repo = repo;


        }

        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetServices()
        {
            var services = await _repo.GetServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            return await _repo.GetServiceByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ServiceType>>> GetServiceTypes()
        {
            return Ok(await _repo.GetServiceTypesAsync());

        }
    }
}