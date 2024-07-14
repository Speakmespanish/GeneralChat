namespace GeneralChat.Core.Domain.Entities
{
    public class Comment
    {
        public int ID { get; set; }

        public string Content { get; set; } = null!;

        public DateTime SentMessageDate { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
