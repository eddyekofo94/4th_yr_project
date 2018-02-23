using System;

namespace mlm.Models.ApplicationUserViewModel
{
    public class UserProfile
    {
        public UserProfile(ApplicationUser user)
        {
            UserEmail = user.Email;
            ImgUrl = user.ImgUrl;
            FirstName = user.FirstName;
            LastName = user.LastName;
            LanguageOfPreference = user.LanguageOfPreference;
            DateOfBirth = user.DateOfBirth;
            Country = user.Country;
            City = user.City;
            Occupation = user.Occupation;
            Gender = user.Gender;
        }

        public string ImgUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LanguageOfPreference { get; set; } // en, fr, es
        public string Country { get; set; } // Ireland, France

        public string City { get; set; }

        public string Occupation { get; set; } // Student / employed etc..
        public string Gender { get; set; } // M/F
    }
}