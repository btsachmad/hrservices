namespace HRServicesAPI.Entities
{
    public class Audit : Base
    {
        public string? Module { get; set; }
        public DateTime Date { get; set; }
        public string? Action { get; set; }

        public string? Detail { get; set; }
    }
}
