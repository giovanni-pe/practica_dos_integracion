using Practica.Application.DTOs;
using Practica.Application.Interfaces;
using Practica.Domain.Entities;

namespace Practica.Application.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<CourseDto>> GetAll() => _repository.GetAllAsync();
        public Task<Course?> GetById(int id) => _repository.GetByIdAsync(id);
        public Task<IEnumerable<Course>> GetByCycle(int cycle) => _repository.GetByCycleAsync(cycle);
        public Task Create(Course course) => _repository.AddAsync(course);
        public Task Update(Course course) => _repository.UpdateAsync(course);
        public Task Delete(int id) => _repository.DeleteAsync(id);
    }
}
