﻿using Exwhyzee.Lojour.Application.Pages;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Core.Authorization.Users;
using Exwhyzee.Lojour.Core.Page;
using Exwhyzee.Lojour.Core.PropertyImage;
using Exwhyzee.Lojour.Web.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Web.Views.Shared.ViewComponents
{

    public class MutePagesViewComponent : ViewComponent
    {

        private readonly IPageAppService _pageAppService;

        public MutePagesViewComponent(IPageAppService pageAppService)
        {
            _pageAppService = pageAppService;
        }
        
        List<PageData> paged = new List<PageData>();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await GetItemAsync();

            return View(item);
        }

        private async Task<List<PageData>> GetItemAsync()
        {
            var page = await _pageAppService.GetAllPages();
            if (page == null)
            {
                return null;
            }
            paged = page.Source.Where(x=>x.PageStatus == Enums.PageStatus.Active && x.PagePosition == Enums.PagePosition.LastFooter).ToList();
            return paged;
        }
    }
}
