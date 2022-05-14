using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Exwhyzee.Lojour.Application.Communities;
using Exwhyzee.Lojour.Application.KindredApp;
using Exwhyzee.Lojour.Application.LGAs;
using Exwhyzee.Lojour.Core.CommunityModel;
using Exwhyzee.Lojour.Core.KindredModel;
using Exwhyzee.Lojour.Core.LgaModel;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.PropertyImages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Exwhyzee.Lojour.Application.Pages;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;

namespace Exwhyzee.Lojour.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyAppService _propertyAppService;
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ICommunityAppService _communityAppService;
        private readonly IKindredAppService _kindredAppService;
        private readonly ILGAsAppService _lgaAppService;
        private readonly IPageAppService _pageAppService;



        public HomeController(IPropertyAppService propertyAppService, IHostingEnvironment env,
            IPropertyImagesAppService propertyImagesAppService, ICommunityAppService communityAppService,
            IKindredAppService kindredAppService, ILGAsAppService lgaAppService, IPageAppService pageAppService)
        {
            _propertyAppService = propertyAppService;
            _hostingEnv = env;
            _propertyImagesAppService = propertyImagesAppService;
            _communityAppService = communityAppService;
            _kindredAppService = kindredAppService;
            _lgaAppService = lgaAppService;
            _pageAppService = pageAppService;
        }


        public async Task<IActionResult> Index()
        {
            var entity = await _propertyAppService.GetAllProperty();



            //var result = entity.Source.Where(x => x.HomeLocation == Enums.HomeLocation.MinnorMain).Take(4).ToList();
            var result = entity.Source.Where(x => x.HomeLocation == Enums.HomeLocation.MinnorMain).OrderByDescending(x => x.SortOrder).Take(4).ToList();
            ViewBag.output = result;

            var result2 = entity.Source.Where(x => x.HomeLocation == Enums.HomeLocation.List).OrderByDescending(x => x.SortOrder).Take(9).ToList();
            ViewBag.list = result2;

           var items = entity.Source.Where(x => x.HomeLocation == Enums.HomeLocation.MajorMain).OrderByDescending(x => x.SortOrder).Take(2).ToList();

            return View(items);
        }


        public async Task<IActionResult> Details(long id, string name, string location, string state)
        {
            
            var entity = await _propertyAppService.Get(id);
            return View(entity);
        }

        public async Task<IActionResult> WebPage(long id, string title)
        {
            var entity = await _pageAppService.Get(id);
            return View(entity);
        }

        //

        public List<SelectListItem> LgaListDp { get; set; }
        public async Task<IActionResult> LGAList(string name)
        {
            List<Lga> items = new List<Lga>();

            var query = await _lgaAppService.GetAll(searchString: name);

            items.AddRange(query.Source.Select(entity => new Lga()
            {
                Id = entity.Id,
                Name = entity.Name


            }));

            LgaListDp = items.Select(a =>
                                new SelectListItem
                                {
                                    Value = a.Name.ToString(),
                                    Text = a.Name
                                }).ToList();
            return new JsonResult(LgaListDp);
        }
        ///

        public List<SelectListItem> CommunityListDp { get; set; }
        public async Task<IActionResult> CommunityList(string name)
        {
            List<CommunityData> items = new List<CommunityData>();

            var query = await _communityAppService.GetAll(searchString: name);

            items.AddRange(query.Source.Select(entity => new CommunityData()
            {
                Id = entity.Id,
                Name = entity.Name


            }));

            CommunityListDp = items.Select(a =>
                                new SelectListItem
                                {
                                    Value = a.Name.ToString(),
                                    Text = a.Name
                                }).ToList();
            return new JsonResult(CommunityListDp);
        }

        ///\
        ///
        public List<SelectListItem> KindredListDp { get; set; }
        public async Task<IActionResult> KindredList(string name)
        {
            List<Kindreds> items = new List<Kindreds>();

            var query = await _kindredAppService.GetAll(searchString: name);

            items.AddRange(query.Source.Select(entity => new Kindreds()
            {
                Id = entity.Id,
                Name = entity.Name


            }));

            KindredListDp = items.Select(a =>
                                new SelectListItem
                                {
                                    Value = a.Name.ToString(),
                                    Text = a.Name
                                }).ToList();
            return new JsonResult(KindredListDp);
        }

       public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mail(string name, string phone, string email, string subject, string messagees)
        {
            string message = "";

            try
            {

                MailMessage mail = new MailMessage();

                //set the addresses 
                mail.From = new MailAddress("Lojour_Home@lojour.com"); //IMPORTANT: This must be same as your smtp authentication address.
                mail.To.Add("Lojour_Home@lojour.com");

                //set the content 

                mail.Subject = "Lojour: Real Estate, Apartments, Hostels and Landed Properties";

                string mess = "Name: " + name + " Phone: "+phone+ ", Email Address: " + email + ", Message: " + messagees;
                mail.Body = mess;
                //send the message 
                SmtpClient smtp = new SmtpClient("mail.lojour.com");

                //IMPORANT:  Your smtp login email MUST be same as your FROM address. 
                NetworkCredential Credentials = new NetworkCredential("Lojour_Home@lojour.com", "Admin@123");
                smtp.Credentials = Credentials;
                smtp.Send(mail);
                TempData["mssg"] = message = "Mail Sent Successfull. Lojour Homes Customer Care will get back to you soon";
            }
            catch (Exception ex)
            {

                TempData["mssg"] = message = "Mail not Sent. Try Again.";
            }
            return RedirectToAction("COntact", "Home");
        }

    }

    public static class UrlHelperExtensions
    {
        private static IHttpContextAccessor HttpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public static string AbsoluteAction(
            this IUrlHelper url,
            string actionName,
            string controllerName,
            object routeValues = null)
        {
            string scheme = HttpContextAccessor.HttpContext.Request.Scheme;
            return url.Action(actionName, controllerName, routeValues, scheme);
        }

    }
}