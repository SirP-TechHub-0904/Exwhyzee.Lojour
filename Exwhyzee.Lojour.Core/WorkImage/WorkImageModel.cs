using Exwhyzee.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Core.WorkImage
{
  public class WorkImageModel
    {
        public long Id { get; set; }
        public long UserProfileId { get; set; }
        public string Url { get; set; }
        public EntityStatus Status { get; set; }
        public bool IsDefault { get; set; }

        public string Title { get; set; }
        public string Address { get; set; }

    }
}
