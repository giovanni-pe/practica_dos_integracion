using Practica.Application.Interfaces;
using Practica.Domain.Entities;


namespace Practica.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<User>> GetAll() => _repository.GetAllAsync();
        public Task<User?> GetById(int id) => _repository.GetByIdAsync(id);
        public Task Create(User user) => _repository.AddAsync(user);
        public Task Update(User user) => _repository.UpdateAsync(user);
        public Task Delete(int id) => _repository.DeleteAsync(id);
    }
}
