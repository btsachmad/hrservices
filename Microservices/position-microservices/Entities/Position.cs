namespace HRServicesAPI.Entities
{
    public class Position : Base
    {
        // TODO : relation to user entity
        // TODO : Index Unique Column Code
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
    }
}
