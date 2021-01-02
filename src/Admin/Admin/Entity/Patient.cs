using System;

namespace IssueManage.Pages.Entity
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
