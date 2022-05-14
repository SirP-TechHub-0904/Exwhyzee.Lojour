using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Core.EstateProperties;
using Exwhyzee.Lojour.Core.PropertyImage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exwhyzee.Lojour.Core.State;
using Exwhyzee.Lojour.Application.States;
using Microsoft.AspNetCore.Authorization;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]

    public class NewPropertyModel : PageModel
    {
        //
        private readonly IPropertyAppService _propertyAppService;
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IStateAppService _stateAppService;

        public NewPropertyModel(IPropertyAppService propertyAppService, IHostingEnvironment env,
            IPropertyImagesAppService propertyImagesAppService, IStateAppService stateAppService)
        {
            _propertyAppService = propertyAppService;
            _hostingEnv = env;
            _propertyImagesAppService = propertyImagesAppService;
            _stateAppService = stateAppService;
        }


       

        //
        [BindProperty]
        public EstatePropertyDto EstatePropertyDto { get; set; }

        public List<StateModel> item { get; set; }
        public async Task OnGet()
        {

            //LoggedInUser = _userManager.GetUserId(HttpContext.User);
            var paggedData = await _stateAppService.GetAll();
            var paggedSource = paggedData.Source.ToList();

            item = paggedSource.ToList();


        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
               
                if (ModelState.IsValid)
                {

                    //file dimension
                    //#region property Image(s)
                    //int imgCount = 0;
                    //if (HttpContext.Request.Form.Files != null && HttpContext.Request.Form.Files.Count > 0)
                    //{
                    //    var newFileName = string.Empty;
                    //    var filePath = string.Empty;
                    //    string pathdb = string.Empty;
                    //    var files = HttpContext.Request.Form.Files;
                    //    foreach (var file in files)
                    //    {
                            
                    //            using (Image sourceImage = Image.FromFile(file))
                    //            {
                    //                Console.WriteLine(sourceImage.Width);
                    //                Console.WriteLine(sourceImage.Height);
                    //            }
                            

                    //    }
                    //}

                    var item = new EstatePropertyDto
                    {
                        PropertyName = EstatePropertyDto.PropertyName,
                        Description = EstatePropertyDto.Description,
                        AgentDetails = EstatePropertyDto.AgentDetails,
                        Longitude = EstatePropertyDto.Longitude,
                        Latitude = EstatePropertyDto.Latitude,
                        Amount = EstatePropertyDto.Amount,
                        PropertyProfile = EstatePropertyDto.PropertyProfile,
                        PropertyType = EstatePropertyDto.PropertyType,
                        PropertyStatus = EstatePropertyDto.PropertyStatus,
                        VerificationStatus = EstatePropertyDto.VerificationStatus,
                        DescriptiveStatus = EstatePropertyDto.DescriptiveStatus,
                        PropertyAddress = EstatePropertyDto.PropertyAddress,
                        DateCreated = DateTime.UtcNow.AddHours(1),
                        IdentificationNumber = "number",
                        State = EstatePropertyDto.State,
                        LGA = EstatePropertyDto.LGA,
                        Community = EstatePropertyDto.Community,
                        Kindred = EstatePropertyDto.Kindred,
                        SortOrder = EstatePropertyDto.SortOrder,
                        HomeLocation = EstatePropertyDto.HomeLocation

                    };

                    var newpropertyId = await _propertyAppService.Add(item);

                    #region property Image(s)
                    int imgCount = 0;
                    if (HttpContext.Request.Form.Files != null && HttpContext.Request.Form.Files.Count > 0)
                    {
                        var newFileName = string.Empty;
                        var filePath = string.Empty;
                        string pathdb = string.Empty;
                        var files = HttpContext.Request.Form.Files;
                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                filePath = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                                imgCount++;
                                var now = DateTime.Now;
                                var uniqueFileName = $"{now.Year}{now.Month}{now.Day}_{now.Hour}{now.Minute}{now.Second}{now.Millisecond}".Trim();




                                var fileExtension = Path.GetExtension(filePath);

                                newFileName = uniqueFileName + fileExtension;

                                // if you wish to save file path to db use this filepath variable + newFileName
                                var fileDbPathName = $"/PropertyImages/".Trim();

                                filePath = $"{_hostingEnv.WebRootPath}{fileDbPathName}".Trim();

                                if (!(Directory.Exists(filePath)))
                                    Directory.CreateDirectory(filePath);

                                var fileName = "";
                                fileName = filePath + $"/{newFileName}".Trim();

                                //Bitmap image = ResizeImage(file.OpenReadStream.file, 400, 800);
                                // copy the file to the desired location from the tempMemoryLocation of IFile and flush temp memory
                                using (FileStream fs = System.IO.File.Create(fileName))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();
                                }

                                #region Save Image Propertie to Db
                                var img = new PropertyImage()
                                {
                                    Url = $"{fileDbPathName}/{newFileName}",
                                    ImageExtension = fileExtension,
                                    DateCreated = DateTime.UtcNow.AddHours(1),
                                    Status = Enums.EntityStatus.Active,
                                    IsDefault = imgCount == 1 ? true : false,
                                    PropertyId = newpropertyId
                                };
                                var saveImageToDb = await _propertyImagesAppService.Insert(img);
                               
                                #endregion

                                if (imgCount >= 20)
                                    break;
                            }
                        }
                    }
                    #endregion

                    return RedirectToPage("Index");
                }

                return Page();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

    }
}