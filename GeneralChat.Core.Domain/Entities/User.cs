namespace GeneralChat.Core.Domain.Entities
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
