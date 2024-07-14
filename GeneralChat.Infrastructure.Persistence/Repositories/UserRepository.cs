using FluentResults;
using GeneralChat.Core.Application.Interfaces.Repositories;
using GeneralChat.Core.Domain.Entities;
using GeneralChat.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GeneralChat.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GeneralChatDatabaseContext _context;

        public UserRepository (GeneralChatDatabaseContext context)
        {
            _context = context;
        }



        private async Task<bool> ValidateIfUserExist (string Mail)
        {
            var Result = await _context.User.FirstOrDefaultAsync(x => x.Email == Mail);

            return Result != null;
        }


        public async Task<Result<User>> Login(string Mail, string Password)
        {
            var ValidationResult = await ValidateIfUserExist(Mail);
            if (!ValidationResult)
                return Result.Fail<User>("User doesn't exist");

            var UserLogged = await _context.User.FirstOrDefaultAsync(x => x.Email == Mail && x.Password == Password);

            return UserLogged is not null ?
                Result.Ok(UserLogged) :
                Result.Fail<User>("User credentials are incorrects");
        }

        public Task<Result<bool>> Register(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ICollection<User>>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Result<User>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
