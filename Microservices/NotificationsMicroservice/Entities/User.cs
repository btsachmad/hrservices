namespace NotificationAPI.Entities
{
    public class User : Base
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid EmployeeId { get; set; }

    }
}
