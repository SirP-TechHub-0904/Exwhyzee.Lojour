using Exwhyzee.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Core.Tour
{
    public class TourModel
    {
        public long Id { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public string Payment { get; set; }
        public string FullName { get; set; }

        public string TourId { get; set; }

    }
}
