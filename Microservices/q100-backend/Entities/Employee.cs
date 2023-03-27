namespace HRServicesAPI.Entities
{
    public class Employee : Base
    {
        public string NIK { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime StartWork { get; set; }
        public Guid PositionID { get; set; }
        public string LengthOfWork { get; set; }
        
        public bool isActive { get; set; } = false;
        
        public DelegationOfAuthority DelegationOfAuthority { get; set; }
    }
}
