using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace mlm.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            SentFriendRequests = new List<Friend>();
            ReceievedFriendRequests = new List<Friend>();
        }

        public virtual ICollection<Friend> SentFriendRequests { get; set; }

        public virtual ICollection<Friend> ReceievedFriendRequests { get; set; }

        [NotMapped]
        public virtual ICollection<Friend> Friends
        {
            get
            {
                var friends = SentFriendRequests.Where(x => x.Approved).ToList();
                friends.AddRange(ReceievedFriendRequests.Where(x => x.Approved));
                return friends;
            }
        }
        
    }
}