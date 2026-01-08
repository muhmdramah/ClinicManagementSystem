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

        public DoctorsController(IGenericRepository<Doctor> doctorRepo)
        {
            _doctorRepo = doctorRepo;
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
            var doctor = new Doctor
            {
                FullName = dto.FullName,
                Phone = dto.Phone,
                Email = dto.Email,
                Specialization = dto.Specialization,
                Bio = dto.Bio,
                ConsultationFee = dto.ConsultationFee,
                DepartmentId = dto.DepartmentId,
            };

            await _doctorRepo.AddAsync(doctor);

            return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
        }
    }
}