using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exwhyzee.Lojour.Core.DegreeObtained
{
  public class DegreeObtainedModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
       
        public string Abbr { get; set; }
        public string Date { get; set; }
       
        public long UserProfileId { get; set; }

    }
}
