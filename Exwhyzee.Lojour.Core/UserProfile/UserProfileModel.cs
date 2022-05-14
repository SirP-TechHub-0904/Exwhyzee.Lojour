using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exwhyzee.Lojour.Core.UserProfile
{
  public class UserProfileModel
    {
        public long Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name= "Surname")]
        public string SurName { get; set; }
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }
        [Display(Name = "Lastname")]
        public string LastName { get; set; }
        [Display(Name = "Contact Address")]
        public string ContactAddress { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public DateTime DateRegistered { get; set; }
        public string UserId { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedinLink { get; set; }
        public string PhotoUrl { get; set; }
        public string ComplementryCardKeywords { get; set; }
        public string LojourId { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }

    }
}

