using Exwhyzee.Enums;
using Exwhyzee.Lojour.Core.PropertyFeatures;
using Exwhyzee.Lojour.Core.PropertyImage;
using Exwhyzee.Lojour.Core.PropertyLandMarks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exwhyzee.Lojour.Application.Tour.Dto
{
    public class TourModelDto
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
