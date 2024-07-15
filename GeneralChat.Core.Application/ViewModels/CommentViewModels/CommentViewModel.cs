namespace GeneralChat.Core.Application.ViewModels.CommentViewModels
{
    public class CommentViewModel
    {
        public int ID { get; set; }

        public string Content { get; set; } = null!;

        public DateTime SentMessageDate { get; set; }

        public string User { get; set; } = null!;
    }
}
