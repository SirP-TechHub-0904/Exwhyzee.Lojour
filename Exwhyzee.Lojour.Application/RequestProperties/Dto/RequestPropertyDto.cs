using Exwhyzee.Enums;
using Exwhyzee.Lojour.Core.PropertyFeatures;
using Exwhyzee.Lojour.Core.PropertyImage;
using Exwhyzee.Lojour.Core.PropertyLandMarks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exwhyzee.Lojour.Application.RequestProperties.Dto
{
    public class RequestPropertyDto
    {

        public long Id { get; set; }
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]

        public string Email { get; set; }
        [Display(Name = "Request type")]

        public string ListType { get; set; }
        [Display(Name = "Request Category")]

        public string Category { get; set; }
        public decimal Location { get; set; }
        public string LandMark { get; set; }
        public string Features { get; set; }
        [Display(Name = "Price Range")]

        public string AmountRange { get; set; }
        [Display(Name = "Mode of Notification")]

        public string AlertType { get; set; }
        [Display(Name = "Duration or interval of Notification")]

        public string AlertDuration { get; set; }
                       public DateTime DateCreated { get; set; }
        public string RequestId { get; set; }
       


    }
}
