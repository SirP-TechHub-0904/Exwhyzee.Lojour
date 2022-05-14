using Exwhyzee.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Application.Pages.Dto
{
   public class PageDataDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public PagePosition PagePosition { get; set; }
        public string Content { get; set; }
        public PageStatus PageStatus { get; set; }
    }
}
