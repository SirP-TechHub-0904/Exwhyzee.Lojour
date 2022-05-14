using Exwhyzee.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Core.RequestProperties
{
    public class RequestProperty
    {
        public long Id { get; set; }
        public string PropertyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ListType { get; set; }
        public string Category { get; set; }
        public decimal Location { get; set; }
        public string LandMark { get; set; }
        public string Features { get; set; }

        public string AmountRange { get; set; }
        public string AlertType { get; set; }
        public string AlertDuration { get; set; }
        public DateTime DateCreated { get; set; }
        public string RequestId { get; set; }

    }
}
