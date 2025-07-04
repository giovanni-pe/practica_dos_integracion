using Practica.Application.DTOs;
using Practica.Domain.Entities;

namespace Practica.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetByCycleAsync(int cycle);
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(int id);
    }
}
