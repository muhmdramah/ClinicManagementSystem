using AutoMapper;
using ClinicManagementSystem.Api.Dtos;
using ClinicManagementSystem.Core.Entities;
using ClinicManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IGenericRepository<Doctor> _doctorRepo;
        private readonly IMapper _mapper;

        public DoctorsController(IGenericRepository<Doctor> doctorRepo, IMapper mapper)
        {
            _doctorRepo = doctorRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _doctorRepo.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor == null)
                return NotFound($"Doctor with ID {id} not found.");

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var doctor = _mapper.Map<Doctor>(dto);

            await _doctorRepo.AddAsync(doctor);

            return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
        }
    }
}