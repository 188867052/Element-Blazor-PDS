using System;

namespace IssueManage.Pages.Entity
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
