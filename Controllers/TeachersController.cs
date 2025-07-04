using Microsoft.AspNetCore.Mvc;
using Practica.Application.Services;
using Practica.Domain.Entities;

namespace Practica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly TeacherService _service;

        public TeachersController(TeacherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAll() =>
            Ok(await _service.GetAll());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Teacher>> GetById(int id)
        {
            var teacher = await _service.GetById(id);
            return teacher is null ? NotFound() : Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Teacher teacher)
        {
            await _service.Create(teacher);
            return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Teacher teacher)
        {
            if (id != teacher.Id) return BadRequest();
            await _service.Update(teacher);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
