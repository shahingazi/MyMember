using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMember.Models
{
    public class MembersActivity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Members Members { get; set; }

    }   
}