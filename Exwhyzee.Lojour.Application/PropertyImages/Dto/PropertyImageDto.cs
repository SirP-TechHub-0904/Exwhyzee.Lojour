using Exwhyzee.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Application.PropertyImages.Dto
{
    public class PropertyImageDto
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public long PropertyId { get; set; }
        public DateTime DateCreated { get; set; }

        public string ImageExtension { get; set; }
        public EntityStatus Status { get; set; }
        public bool IsDefault { get; set; } = false;

    }
}
