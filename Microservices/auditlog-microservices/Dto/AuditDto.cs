namespace HRServicesAPI.Dto
{
    public class QueryParams {
        public string? search { get; set; }
        public string? module { get; set; }
    }

    public class AuditRead
    {
        public Guid Id { get; set; }
        public string? Module { get; set; }
        public DateTime Date { get; set; }
        public string? Action { get; set; }

        public string? Detail { get; set; }
    }

    public class AuditRequest
    {
        public string? Module { get; set; }
        public DateTime Date { get; set; }
        public string? Action { get; set; }

        public string? Detail { get; set; }
    }
}
