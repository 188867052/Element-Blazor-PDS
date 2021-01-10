using System;

namespace IssueManage.Pages.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal Price { get; set; }
        public Sex Sex { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
