using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mlm.Models.Friendship
{
    public class Friendship
    {
        public Friendship()
        {
           
        }

        [Key] public Guid FriendshipId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [DataType(DataType.Date)]
        public DateTime FriendshipTime { get; set; }
        public string FriendId { get; set; }
        public string FriendEmail { get; set; }
    }
}