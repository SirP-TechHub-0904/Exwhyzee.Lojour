using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.Communities;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.KindredApp;
using Exwhyzee.Lojour.Application.LGAs;
using Exwhyzee.Lojour.Application.Pages;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Application.RequestProperties;
using Exwhyzee.Lojour.Application.RequestProperties.Dto;
using Exwhyzee.Lojour.Application.Tour.Dto;
using Exwhyzee.Lojour.Core.Tour;
using Exwhyzee.Lojour.Data.Repository.Tour;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Exwhyzee.Lojour.Website.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyAppService _propertyAppService;
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ICommunityAppService _communityAppService;
        private readonly IKindredAppService _kindredAppService;
        private readonly ILGAsAppService _lgaAppService;
        private readonly IPageAppService _pageAppService;
        private readonly IRequestPropertyAppService _requestPropertyAppService;
        private readonly ITourRepository _tourRepository;

        public PropertyController(IPropertyAppService propertyAppService, IHostingEnvironment env, ITourRepository tourRepository,
            IPropertyImagesAppService propertyImagesAppService, ICommunityAppService communityAppService,
            IKindredAppService kindredAppService, ILGAsAppService lgaAppService, IPageAppService pageAppService, IRequestPropertyAppService requestPropertyAppService)
        {
            _propertyAppService = propertyAppService;
            _hostingEnv = env;
            _propertyImagesAppService = propertyImagesAppService;
            _communityAppService = communityAppService;
            _kindredAppService = kindredAppService;
            _lgaAppService = lgaAppService;
            _pageAppService = pageAppService;
            _requestPropertyAppService = requestPropertyAppService;
            _tourRepository = tourRepository;
        }

        public async Task<IActionResult> Search(string searchString, int? propertyDesc, int? page)
        {
            var entity = await _propertyAppService.GetAllProperty(searchString: searchString);

            var items = entity.Source.Where(x => x.PropertyStatus == Enums.PropertyStatus.Active);
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            ViewBag.item = searchString;
            ViewBag.count = items.Count();
            ViewBag.Properties = items.ToPagedList(pageNumber, 12);
            return View();
        }

        public async Task<IActionResult> Rent(string searchString, int? propertyDesc, int? page)
        {
            var entity = await _propertyAppService.GetAllProperty(searchString: searchString);

            var items = entity.Source.Where(x => x.DescriptiveStatus == Enums.DescriptiveStatus.ForRent && x.PropertyStatus == Enums.PropertyStatus.Active);
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            ViewBag.item = searchString;
            ViewBag.count = items.Count();
            ViewBag.Properties = items.ToPagedList(pageNumber, 12);
            return View();
        }

        public async Task<IActionResult> Sale(string searchString, int? propertyDesc, int? page)
        {
            var entity = await _propertyAppService.GetAllProperty(searchString: searchString);

            var items = entity.Source.Where(x => x.DescriptiveStatus == Enums.DescriptiveStatus.ForSale && x.PropertyStatus == Enums.PropertyStatus.Active).OrderByDescending(x => x.SortOrder).ToList();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            ViewBag.item = searchString;
            ViewBag.count = items.Count();
            ViewBag.Properties = items.ToPagedList(pageNumber, 12);
            return View();
        }


        public async Task<IActionResult> ServicedApartment(string searchString, int? propertyDesc, int? page)
        {
            var entity = await _propertyAppService.GetAllProperty(searchString: searchString);

            var items = entity.Source.Where(x => x.PropertyType.Contains("Service Apartment") && x.PropertyStatus == Enums.PropertyStatus.Active).ToList();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            ViewBag.item = searchString;
            ViewBag.count = items.Count();

            ViewBag.Properties = items.ToPagedList(pageNumber, 12);
            return View();
        }

        public async Task<IActionResult> Hostel(string searchString, int? propertyDesc, int? page)
        {
            var entity = await _propertyAppService.GetAllProperty(searchString: searchString);

            var items = entity.Source.Where(x => x.PropertyType.Contains("Hostel") && x.PropertyStatus == Enums.PropertyStatus.Active).ToList();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            ViewBag.item = searchString;
            ViewBag.count = items.Count();
            ViewBag.Properties = items.ToPagedList(pageNumber, 12);
            return View();
        }

        public async Task<IActionResult> Lease(string searchString, int? propertyDesc, int? page)
        {
            var entity = await _propertyAppService.GetAllProperty(searchString: searchString);

            var items = entity.Source.Where(x => x.DescriptiveStatus == Enums.DescriptiveStatus.ShortLet && x.PropertyStatus == Enums.PropertyStatus.Active).ToList();

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            ViewBag.item = searchString;
            ViewBag.count = items.Count();

            ViewBag.Properties = items.ToPagedList(pageNumber, 12);
            return View();
        }

        public async Task<ActionResult> Tour(long id)
        {
            var entity = await _propertyAppService.Get(id);
            ViewBag.entity = entity;
            return View(entity);
        }


        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Tour(string email, string phone, string date, string time, string payment, string fullname)
        {
            try
            {
                var item = new TourModel
                {
                    PhoneNumber = phone,
                    Email = email,
                    Date = date,
                    Time = time,
                    Payment = payment,
                    FullName = fullname

                };

                var Id = await _tourRepository.Add(item);
                return RedirectToAction("Complete", new { id = Id });
            }
            catch (Exception c)
            {

            }
            return View();
        }


        public async Task<ActionResult> Complete(long id)
        {
            var item = await _tourRepository.Get(id);
            return View(item);
        }
        // GET: Blog/Create
        public ActionResult Request()
        {

            return View();
        }


        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Request(RequestPropertyDto entity)
        {
            try
            {
                var item = new RequestPropertyDto
                {
                    PropertyName = entity.PropertyName,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    ListType = entity.ListType,
                    Category = entity.Category,
                    Location = entity.Location,
                    LandMark = entity.LandMark,
                    Features = entity.Features,
                    AmountRange = entity.AmountRange,
                    AlertType = entity.AlertType,
                    AlertDuration = entity.AlertDuration,
                    DateCreated = DateTime.UtcNow.AddHours(1)


                };

                var Id = await _requestPropertyAppService.Add(item);
                return RedirectToAction("Submitted", new { id = Id });
            }
            catch (Exception c)
            {

            }
            return View(entity);
        }

        public async Task<IActionResult> Submitted(long id)
        {
            var item = await _requestPropertyAppService.Get(id);
            return View(item);
        }

       


        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      

        public async Task<IActionResult> FindAHome(string searchString, int? propertyDesc, int? page)
        {
            if (!String.IsNullOrEmpty(searchString))
            {


                var entity = await _propertyAppService.GetAllProperty(searchString: searchString);

                var items = entity.Source.Where(x => x.PropertyStatus == Enums.PropertyStatus.Active);
                var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

                ViewBag.item = searchString;
                ViewBag.count = items.Count();
                ViewBag.Properties = items.ToPagedList(pageNumber, 12);
            }
            return View();
        }

        public async Task<IActionResult> AllProperty(string searchString, int? propertyDesc, int? page)
        {
           

                var entity = await _propertyAppService.GetAllProperty(searchString: searchString);

                var items = entity.Source.Where(x => x.PropertyStatus == Enums.PropertyStatus.Active);
                var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

                ViewBag.item = searchString;
                ViewBag.count = items.Count();
                ViewBag.Properties = items.ToPagedList(pageNumber, 12);
           
            return View();
        }


    }
}