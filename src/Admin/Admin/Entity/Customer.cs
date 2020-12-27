using System;

namespace Element.Admin.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPersion { get; set; }
        public string ContactPhone { get; set; }
        public string ReceivePersion { get; set; }
        public string ReceivePhone { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
