using System;
namespace HRServicesAPI.Entities
{
	public class Leave: Base
	{
        public Guid IdEmployee { get; set; }
        public int Level { get; set; }
        public DateOnly StartDt { get; set; }
        public DateOnly EndDt { get; set; }
        public DateTime ExpiredDt { get; set; }
        public DateTime? ApprovalDt { get; set; }
        public Guid? IdApprover { get; set; }
        public bool? AutoApprove { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
    }
}

