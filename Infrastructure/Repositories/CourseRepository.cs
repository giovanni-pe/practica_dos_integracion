using Microsoft.EntityFrameworkCore;
using Practica.Application.DTOs;
using Practica.Application.Interfaces;
using Practica.Domain.Entities;
using Practica.Infrastructure.Data;

namespace Practica.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            return await _context.Courses
                .Include(c => c.Teacher)
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Credits = c.Credits,
                    WeeklyHours = c.WeeklyHours,
                    Cycle = c.Cycle,
                    TeacherId = c.TeacherId,
                    TeacherFirstName = c.Teacher != null ? c.Teacher.FirstName : null,
                    TeacherLastName = c.Teacher != null ? c.Teacher.LastName : null,
                    TeacherEmail = c.Teacher != null ? c.Teacher.Email : null
                })
                .ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id) =>
            await _context.Courses.Include(c => c.Teacher)
                                  .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Course>> GetByCycleAsync(int cycle) =>
            await _context.Courses.Include(c => c.Teacher)
                                  .Where(c => c.Cycle == cycle)
                                  .ToListAsync();

        public async Task AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }

}
