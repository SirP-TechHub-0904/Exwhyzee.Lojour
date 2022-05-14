using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exwhyzee.Lojour.Core.MembershipOfLearneredSociety
{
  public class MembershipOfLearneredSocietyModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Abbr { get; set; }
       
        public long UserProfileId { get; set; }

    }
}
