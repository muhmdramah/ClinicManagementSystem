using AutoMapper;
using ClinicManagementSystem.Api.Dtos.Doctor;
using ClinicManagementSystem.Core.Entities;
using ClinicManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var doctors = await _doctorRepo.GetAllAsync(new[] { "Department" });

            var data = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorRepo.FindAsync(d => d.Id == id, new[] { "Department" });

            if (doctor == null)
                return NotFound($"Doctor with ID {id} not found.");

            var data = _mapper.Map<DoctorDto>(doctor);

            return Ok(data);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingDoctor = await _doctorRepo.GetByIdAsync(id);

            if (existingDoctor == null)
                return NotFound($"Doctor with ID {id} not found.");

            _mapper.Map(dto, existingDoctor);

            await _doctorRepo.UpdateAsync(existingDoctor);

            return NoContent(); // 204 No Content (Standard for Update)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);

            if (doctor == null)
                return NotFound($"Doctor with ID {id} not found.");

            await _doctorRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}