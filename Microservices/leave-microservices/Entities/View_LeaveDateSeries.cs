using System;
namespace HRServicesAPI.Entities
{
	public class View_LeaveDateSeries
	{
        public Guid Id { get; set; }
        public Guid IdEmployee { get; set; }
        public string Year { get; set; }
        public DateTime Date { get; set; }
    }
}

