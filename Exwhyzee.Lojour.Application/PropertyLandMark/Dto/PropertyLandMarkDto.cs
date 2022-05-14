using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Application.PropertyLandMark.Dto
{
   public class PropertyLandMarkDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Distance { get; set; }
        public string LandMark { get; set; }
        public long PropertyId { get; set; }
    }
}
