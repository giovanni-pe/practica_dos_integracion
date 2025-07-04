using Practica.Application.Interfaces;
using Practica.Domain.Entities;

namespace Practica.Application.Services
{
    public class TeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Teacher>> GetAll() => _repository.GetAllAsync();
        public Task<Teacher?> GetById(int id) => _repository.GetByIdAsync(id);
        public Task Create(Teacher teacher) => _repository.AddAsync(teacher);
        public Task Update(Teacher teacher) => _repository.UpdateAsync(teacher);
        public Task Delete(int id) => _repository.DeleteAsync(id);
    }
}
