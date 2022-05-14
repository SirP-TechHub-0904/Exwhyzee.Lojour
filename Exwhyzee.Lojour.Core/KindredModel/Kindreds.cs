using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Core.KindredModel
{
   public class Kindreds
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Community { get; set; }
        
        public long CommunityId { get; set; }
    }
}
