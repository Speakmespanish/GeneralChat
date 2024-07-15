using FluentResults;
using GeneralChat.Core.Application.ViewModels.CommentViewModels;

namespace GeneralChat.Core.Application.Interfaces.Services
{
    public interface ICommentService
    {
        public Task<Result<bool>> CreateComment (CreateCommentViewModel createCommentViewModel);
        public Task<Result<ICollection<CommentViewModel>>> GetAllComments ();
    }
}
