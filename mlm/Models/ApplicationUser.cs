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
//         user can add a profile pic
        public string ImgUrl { get; set; }
        [Display(Name = "First name")] public string FirstName { get; set; }
        [Display(Name = "Last name")] public string LastName { get; set; }
        [Display(Name = "Date Of Birth")] public DateTime DateOfBirth { get; set; }
        [Display(Name = "Language Of Choice")] public string LanguageOfPreference { get; set; } // en, fr, es
        [Display(Name = "Country of Origin")] public string Country { get; set; } // Ireland, France

        public string City { get; set; }

        public string Occupation { get; set; } // Student / employed etc..
        [Display(Name = "Gender")] public string Gender { get; set; } // M/F

//        public string FriendshipId { get; set; }
        private ICollection<Friendship.Friendship> _friendhips;

        public virtual ICollection<Friendship.Friendship> Friendships
        {
            get => _friendhips ?? (_friendhips = new List<Friendship.Friendship>());
            set => _friendhips = value;
        }
    }
}