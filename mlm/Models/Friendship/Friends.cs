using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mlm.Models.Friendship
{
    public class Friends
    {
        [Key] public Guid FriendshipId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string FriendEmail { get; set; }
        private ICollection<ApplicationUser> _friend;

        public virtual ICollection<ApplicationUser> Friendships
        {
            get => _friend ?? (_friend = new List<ApplicationUser>());
            set => _friend = value;
        }

//        public ApplicationUser User { get; set; }
//        [NotMapped] public virtual ICollection<string> Friendship { get; set; }
    }

    public enum FriendRequestFlag
    {
        None,
        Approved,
        Rejected,
        Blocked,
        Spam
    };
}