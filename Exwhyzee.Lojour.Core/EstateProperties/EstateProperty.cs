using Exwhyzee.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Core.EstateProperties
{
    public class EstateProperty
    {
        public long Id { get; set; }
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public string AgentDetails { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public decimal Amount { get; set; }
        public string PropertyProfile { get; set; }
        public string PropertyType { get; set; }

        public PropertyStatus PropertyStatus { get; set; }
        
        public VerificationStatus VerificationStatus { get; set; }
        public DescriptiveStatus DescriptiveStatus { get; set; }

        public string PropertyAddress { get; set; }


        public DateTime DateCreated { get; set; }
        public string IdentificationNumber { get; set; }

        public string State { get; set; }
        public string LGA { get; set; }
        public string Community { get; set; }
        public string Kindred { get; set; }
        public int SortOrder { get; set; }

        public bool RateOne { get; set; }
        public bool RateTwo { get; set; }
        public bool RateThree { get; set; }
        public bool RateFour { get; set; }
        public bool RateFive { get; set; }

        public HomeLocation HomeLocation { get; set; }

        public HomeLocation Position { get; set; }

        public string Username { get; set; }
        public string Video { get; set; }

        public string FullName { get; set; }
        public string PropertyLevel { get; set; }
        public string MapLink { get; set; }
        




    }
}
