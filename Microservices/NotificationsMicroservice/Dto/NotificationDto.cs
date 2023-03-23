using NotificationAPI.Entities;

namespace NotificationAPI.Dto
{
    public class NotificationDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid UserId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Status { get; set; }
    }
}
