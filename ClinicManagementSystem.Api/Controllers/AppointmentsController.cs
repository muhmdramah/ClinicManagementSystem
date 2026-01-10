using AutoMapper;
using ClinicManagementSystem.Api.Dtos;
using ClinicManagementSystem.Api.Dtos.Appointment;
using ClinicManagementSystem.Core.Entities;
using ClinicManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IGenericRepository<Appointment> _appointmentRepo;
        private readonly IMapper _mapper;

        public AppointmentsController(IGenericRepository<Appointment> appointmentRepo, IMapper mapper)
        {
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Eager Loading: Getting the Doctor and the Patient
            var appointments = await _appointmentRepo.GetAllAsync(new[] { "Doctor", "Patient" });
            var data = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _appointmentRepo.FindAsync(a => a.Id == id, new[] { "Doctor", "Patient" });

            if (appointment == null)
                return NotFound($"Appointment with ID {id} not found.");

            return Ok(_mapper.Map<AppointmentDto>(appointment));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appointment = _mapper.Map<Appointment>(dto);

            // appointment.Status = "Pending";

            await _appointmentRepo.AddAsync(appointment);

            return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, appointment);
        }

        // PUT: api/Appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingAppointment = await _appointmentRepo.GetByIdAsync(id);

            if (existingAppointment == null)
                return NotFound($"Appointment with ID {id} not found.");

            _mapper.Map(dto, existingAppointment);

            await _appointmentRepo.UpdateAsync(existingAppointment);

            return NoContent();
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentRepo.GetByIdAsync(id);

            if (appointment == null)
                return NotFound($"Appointment with ID {id} not found.");

            await _appointmentRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}