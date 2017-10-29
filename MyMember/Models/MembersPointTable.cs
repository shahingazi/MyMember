namespace MyMember.Models
{
    public class MembersPointTable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public int Point { get; set; }
        public int PointValue { get; set; } 
        public int MinimumPayoutPoint { get; set; }
    }
}