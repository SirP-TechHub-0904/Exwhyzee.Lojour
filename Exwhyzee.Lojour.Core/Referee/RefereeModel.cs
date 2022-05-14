using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exwhyzee.Lojour.Core.Referee
{
  public class RefereeModel
    {
        public long Id { get; set; }
        public string Office { get; set; }
        public string Name { get; set; }
       
        public string EmailAndPhone { get; set; }
       
        public long UserProfileId { get; set; }

    }
}
