using System.ComponentModel.DataAnnotations;

namespace GeneralChat.Core.Application.ViewModels.CommentViewModels
{
    public class CreateCommentViewModel
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public string Content { get; set; } = null!;
    }
}
