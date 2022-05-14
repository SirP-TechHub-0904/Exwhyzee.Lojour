using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Core.JobAnalysis
{
  public class JobAnalysisModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Count { get; set; }
        public long UserProfileId { get; set; }

    }
}
