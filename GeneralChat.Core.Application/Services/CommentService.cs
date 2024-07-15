using FluentResults;
using GeneralChat.Core.Application.Interfaces.Repositories;
using GeneralChat.Core.Application.Interfaces.Services;
using GeneralChat.Core.Application.ViewModels.CommentViewModels;

namespace GeneralChat.Core.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentrepository;

        public CommentService (ICommentRepository commentrepository)
        {
            _commentrepository = commentrepository;
        }



        public async Task<Result<bool>> CreateComment(CreateCommentViewModel createCommentViewModel)
        {
            try
            {
                var CommentResult = await _commentrepository.CreateComment(new Domain.Entities.Comment()
                {
                    Content = createCommentViewModel.Content,
                    UserID = createCommentViewModel.UserID,
                    SentMessageDate = DateTime.Now
                });

                return CommentResult.IsSuccess ?
                    Result.Ok(true) :
                    Result.Fail<bool>(CommentResult.Reasons.First().Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result<ICollection<CommentViewModel>>> GetAllComments()
        {
            try
            {
                var Comments = await _commentrepository.GetComments();

                if (Comments.IsFailed)
                    return Result.Fail<ICollection<CommentViewModel>>(Comments.Reasons.First().Message);

                ICollection<CommentViewModel> CommentToList = new List<CommentViewModel>();
                foreach (var comment in Comments.ValueOrDefault)
                {
                    CommentToList.Add(new CommentViewModel()
                    {
                        ID = comment.ID,
                        Content = comment.Content,
                        SentMessageDate = comment.SentMessageDate,
                        User = comment.User.Name
                    });
                }
                return CommentToList.Any() ?
                    Result.Ok(CommentToList) :
                    Result.Fail<ICollection<CommentViewModel>>("Couldn't get comments");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
