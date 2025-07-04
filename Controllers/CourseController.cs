using Microsoft.AspNetCore.Mvc;
using Practica.Application.Services;
using Practica.Domain.Entities;

namespace Practica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly CourseService _service;

        public CoursesController(CourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll() =>
            Ok(await _service.GetAll());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await _service.GetById(id);
            return course == null ? NotFound() : Ok(course);
        }

        [HttpGet("cycle/{cycle:int}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetByCycle(int cycle) =>
            Ok(await _service.GetByCycle(cycle));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Course course)
        {
            await _service.Create(course);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Course course)
        {
            if (id != course.Id) return BadRequest();
            await _service.Update(course);
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
