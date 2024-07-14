using FluentResults;
using GeneralChat.Core.Application.Interfaces.Repositories;
using GeneralChat.Core.Domain.Entities;
using GeneralChat.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GeneralChat.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly GeneralChatDatabaseContext _context;

        public CommentRepository (GeneralChatDatabaseContext context)
        {
            _context = context;
        }
        


        public async Task<Result<bool>> DeleteComment(int id)
        {
            var CommentToDelete = await _context.Comment.FindAsync(id);

            if (CommentToDelete is null)
                return Result.Fail<bool>("Comment not found with that id");

            var ResultToDelete = _context.Comment.Remove(CommentToDelete);
            var ResultProccess = await _context.SaveChangesAsync();

            return ResultProccess > 0 ?
                Result.Ok(true) :
                Result.Fail<bool>("An error occurred, comment couldn't be deleted");
        }

        public async Task<Result<ICollection<Comment>>> GetComments()
        {
            var Comments = await _context.Comment.ToListAsync();

            return Comments.Any() ?
                Result.Ok((ICollection<Comment>)(Comments.OrderBy(x => x.SentMessageDate)).ToList()) :
                Result.Fail<ICollection<Comment>>("Theren't comments to list");
        }

        public async Task<Result<bool>> CreateComment(Comment comment)
        {
            var ResultCommentToCreate = await _context.Comment.AddAsync(comment);
            var ResultProccess = await _context.SaveChangesAsync();

            return ResultProccess > 0 ?
                Result.Ok(true) :
                Result.Fail<bool>("An error occurred, couldn't be created the comment");
        }
    }
}
