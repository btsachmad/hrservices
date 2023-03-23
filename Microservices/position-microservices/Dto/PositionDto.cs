namespace HRServicesAPI.Dto
{
    public class PositionRead
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
    }

    public class PositionRequest
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
    }
}
