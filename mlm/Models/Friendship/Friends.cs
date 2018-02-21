using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mlm.Models.Friendship
{
    public class Friends : ApplicationUser
    {
//        [Key, Column(Order = 0)]
//        public int RequestedById { get; set; } 
//        [Key, Column(Order = 1)]
//        public int RequestedToId { get; set; } 
//        public virtual ApplicationUser RequestedBy { get; set; }
//        public virtual ApplicationUser RequestedTo { get; set; }
//
//        public DateTime? RequestTime { get; set; }
//
//        public DateTime? BecameFriendsTime { get; set; }
//
//        public FriendRequestFlag FriendRequestFlag { get; set; }
//
//        [NotMapped]
//        public bool Approved => FriendRequestFlag == FriendRequestFlag.Approved;
//
//        public void AddFriendRequest(ApplicationUser user, ApplicationUser friendUser)
//        {
//            var friendRequest = new Friend()
//            {
//                RequestedBy = user,
//                RequestedTo = friendUser,
//                RequestTime = DateTime.Now,
//                FriendRequestFlag = FriendRequestFlag.None
//            };
//            user.SentFriendRequests.Add(friendRequest);
//        }
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