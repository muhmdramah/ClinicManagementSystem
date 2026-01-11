using AutoMapper;
using ClinicManagementSystem.Api.Dtos.Doctor;
using ClinicManagementSystem.Api.Dtos.Patient;
using ClinicManagementSystem.Core.Entities;
using ClinicManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IGenericRepository<Patient> _patientRepo;
        private readonly IMapper _mapper;

        public PatientsController(IGenericRepository<Patient> patientRepo, IMapper mapper)
        {
            _patientRepo = patientRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientRepo.GetAllAsync();

            var data = _mapper.Map<IEnumerable<PatientDto>>(patients);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);

            if (patient == null)
                return NotFound($"Patient with ID {id} not found.");

            var data = _mapper.Map<PatientDto>(patient);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patient = _mapper.Map<Patient>(dto);

            await _patientRepo.AddAsync(patient);

            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingPatient = await _patientRepo.GetByIdAsync(id);

            if (existingPatient == null)
                return NotFound($"Patient with ID {id} not found.");

            _mapper.Map(dto, existingPatient);

            await _patientRepo.UpdateAsync(existingPatient);

            return NoContent(); // 204 No Content (Standard for Update)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);

            if (patient == null)
                return NotFound($"Patient with ID {id} not found.");

            await _patientRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}
