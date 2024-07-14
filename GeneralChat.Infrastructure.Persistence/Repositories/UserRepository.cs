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

        public async Task<Result<bool>> Register(User user)
        {
            var ValidationResult = await ValidateIfUserExist(user.Email);
            if (ValidationResult)
                return Result.Fail<bool>("Couldn't created a new user, the user already exist");

            var ResultUser = await _context.User.AddAsync(user);
            var ResultProccess = await _context.SaveChangesAsync();

            return ResultProccess > 0 && ResultUser.Entity is not null ?
                Result.Ok(true) :
                Result.Fail<bool>("An error ocurred, user couldn't be created");
        }

        public async Task<Result<ICollection<User>>> GetUsers()
        {
            var Users = await _context.User.ToListAsync();

            return Users.Any() ?
                Result.Ok((ICollection<User>)(Users)) :
                Result.Fail<ICollection<User>>("Theren't users to list");
        }

        public async Task<Result<User>> GetUserById(int id)
        {
            var User = await _context.User.FindAsync(id);

            return User is not null ?
                Result.Ok(User) :
                Result.Fail<User>("Theren't user with that id");
        }
    }
}
