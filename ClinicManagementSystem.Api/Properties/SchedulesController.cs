using AutoMapper;
using ClinicManagementSystem.Api.Dtos.Schedule;
using ClinicManagementSystem.Core.Entities;
using ClinicManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IGenericRepository<DoctorSchedule> _scheduleRepo;
        private readonly IMapper _mapper;

        public SchedulesController(IGenericRepository<DoctorSchedule> scheduleRepo, IMapper mapper)
        {
            _scheduleRepo = scheduleRepo;
            _mapper = mapper;
        }

        // 1. Get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _scheduleRepo.GetAllAsync(new[] { "Doctor" });
            return Ok(_mapper.Map<IEnumerable<ScheduleDto>>(schedules));
        }

        // 2. Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var schedule = await _scheduleRepo.FindAsync(s => s.Id == id, new[] { "Doctor" });

            if (schedule == null)
                return NotFound($"Schedule with ID {id} not found.");

            return Ok(_mapper.Map<ScheduleDto>(schedule));
        }

        // 3. Add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateScheduleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var schedule = _mapper.Map<DoctorSchedule>(dto);
            await _scheduleRepo.AddAsync(schedule);

            return Ok(_mapper.Map<ScheduleDto>(schedule));
        }

        // 4. Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateScheduleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingSchedule = await _scheduleRepo.GetByIdAsync(id);

            if (existingSchedule == null)
                return NotFound($"Schedule with ID {id} not found.");

            _mapper.Map(dto, existingSchedule);

            await _scheduleRepo.UpdateAsync(existingSchedule);

            return NoContent();
        }

        // 5. Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var schedule = await _scheduleRepo.GetByIdAsync(id);

            if (schedule == null)
                return NotFound($"Schedule with ID {id} not found.");

            await _scheduleRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}