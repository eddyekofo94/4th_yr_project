using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using mlm.Models.Friendship;
using Microsoft.AspNetCore.Identity;

namespace mlm.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
//        public ApplicationUser()
//        {
//            SentFriendRequests = new List<Friend>();
//            ReceievedFriendRequests = new List<Friend>();
//        }

//         user can add a profile pic
        public string ImgUrl { get; set; }
        public Guid FriendshipId { get; set; }

        public virtual Friends Friedships { get; set; }
//
//        public virtual ICollection<Friend> ReceievedFriendRequests { get; set; }

//           get
        //            {
        //                var friends = SentFriendRequests.Where(x => x.Approved).ToList();
        //                friends.AddRange(ReceievedFriendRequests.Where(x => x.Approved));
        //                return friends;
        //            }
    }
}