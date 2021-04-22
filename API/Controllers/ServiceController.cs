using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data;
using Core.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interface;
using Core.Spec;
using API.Dto;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : BaseApiController
    {
        private readonly IGenericRepo<Service> _serviceRepo;
        private readonly IGenericRepo<ServiceType> _serviceTypeRepo;
        private readonly IGenericRepo<CommType> _commTypeRepo;
        private readonly IGenericRepo<DesignOption> _designOptionRepo;
        private readonly IMapper _mapper;

        public ServiceController(IGenericRepo<Service> serviceRepo,
        IGenericRepo<ServiceType> serviceTypeRepo, IGenericRepo<CommType> commTypeRepo,
        IGenericRepo<DesignOption> designOptionRepo, IMapper mapper)
        {
            _mapper = mapper;
            _designOptionRepo = designOptionRepo;
            _commTypeRepo = commTypeRepo;
            _serviceTypeRepo = serviceTypeRepo;
            _serviceRepo = serviceRepo;


        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ServiceToReturnDto>>> GetServices()
        {
            var spec = new ServiceWithTypeSpec();
            var services = await _serviceRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Service>, IReadOnlyList<ServiceToReturnDto>>(services));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ServiceToReturnDto>> GetService(int id)
        {
            var spec = new ServiceWithTypeSpec(id);
            var service = await _serviceRepo.GetEntityWithSpec(spec);
            if (service == null) 
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<Service, ServiceToReturnDto>(service);

            

        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ServiceType>>> GetServiceTypes()
        {
            return Ok(await _serviceTypeRepo.ListAllAsync());

        }

        [HttpGet("commTypes")]
        public async Task<ActionResult<IReadOnlyList<CommType>>> GetCommTypes()
        {
            return Ok(await _commTypeRepo.ListAllAsync());
        }

        [HttpGet("design")]
        public async Task<ActionResult<IReadOnlyList<DesignOption>>> GetDesignOptions()
        {
            return Ok(await _designOptionRepo.ListAllAsync());
        }
    }
}