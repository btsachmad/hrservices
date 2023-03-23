namespace HRServicesAPI.Dto
{
    public class LeaveCreate
    {
        public Guid IdEmployee { get; set; }
        public int Level { get; set; }
        public string StartDt { get; set; }
        public string EndDt { get; set; }
        public DateTime ExpiredDt { get; set; }
        public string Status { get; set; }

        public LeaveCreate()
        {
            DateTime CurrentDate = DateTime.Now;
            TimeSpan Time = new TimeSpan(2, 0, 0, 0);
            ExpiredDt = CurrentDate.Add(Time);
            Status = "NEED_APPROVAL";
        }
    }

    public class LeaveApprove
    {
        public Guid Id { get; set; }
        public Guid IdApprover { get; set; }
        public DateTime ApprovalDt { get; set; }
        public string Status { get; set; }

        public LeaveApprove()
        {
            ApprovalDt = DateTime.Now;
            Status = "APPROVED";
        }
    }

    public class LeaveReject
    {
        public Guid Id { get; set; }
        public Guid IdApprover { get; set; }
        public DateTime ApprovalDt { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; }

        public LeaveReject()
        {
            ApprovalDt = DateTime.Now;
            Status = "REJECTED";
        }
    }

    public class LeaveRead
    {
        public Guid Id { get; set; }
        public Guid IdEmployee { get; set; }
        public int? Level { get; set; }
        public string? StartDt { get; set; }
        public string? EndDt { get; set; }
        public DateTime? ExpiredDt { get; set; }
        public DateTime? ApprovalDt { get; set; }
        public Guid? IdApprover { get; set; }
        public bool? AutoApprove { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
    }
}
