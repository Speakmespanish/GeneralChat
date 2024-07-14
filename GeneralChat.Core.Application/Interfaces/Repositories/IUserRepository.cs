using FluentResults;
using GeneralChat.Core.Domain.Entities;

namespace GeneralChat.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<Result<User>> Login (string Mail, string Password);
        public Task<Result<bool>> Register (User user);
        public Task<Result<ICollection<User>>> GetUsers ();
        public Task<Result<User>> GetUserById (int id);
    }
}
