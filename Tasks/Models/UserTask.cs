namespace Tasks.Models
{
    public class UserTask
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public required string Subject { get; set; }

        public DateTime TargetDate { get; set; }

        public bool IsCompleted { get; set; }

        public virtual User User { get; set; }
    }
}
