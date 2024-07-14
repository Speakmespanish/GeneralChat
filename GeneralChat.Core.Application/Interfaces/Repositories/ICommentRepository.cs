using FluentResults;
using GeneralChat.Core.Domain.Entities;

namespace GeneralChat.Core.Application.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        public Result<ICollection<Comment>> GetComments ();
        public Result<bool> DeleteComment (int id);
    }
}
