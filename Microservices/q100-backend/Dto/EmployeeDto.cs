namespace HRServicesAPI.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string NIK { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime StartWork { get; set; }
        public string PositionID { get; set; }
        public DateTime LengthOfWork { get; set; }
    }
}
