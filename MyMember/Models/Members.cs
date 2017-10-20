using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMember.Models
{
    public class Members
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<MembersActivity> Students { get; set; }
    }

    public class GroupsMember
    {
        public int Id { get; set; }
        public Members Members { get; set; }
        public DateTime CreateAt { get; set; }        
    }

    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime CreateAt { get; set; }
    }
}