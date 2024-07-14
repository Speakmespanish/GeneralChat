using FluentResults;
using GeneralChat.Core.Domain.Entities;

namespace GeneralChat.Core.Application.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        public Task<Result<ICollection<Comment>>> GetComments ();
        public Task<Result<bool>> DeleteComment (int id);
        public Task<Result<bool>> CreateComment (Comment comment);
    }
}
