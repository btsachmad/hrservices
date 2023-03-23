namespace NotificationAPI.Entities
{
    public class Notification : Base
    {
        public string Title { get; set; }

        public Guid EmplayeeId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Status { get; set; }
    }
}
