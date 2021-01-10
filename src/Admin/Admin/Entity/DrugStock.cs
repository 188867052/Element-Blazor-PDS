namespace IssueManage.Pages.Entity
{
    public class DrugStock
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public Student Drug { get; set; }
        public int Amount { get; set; }
    }
}
