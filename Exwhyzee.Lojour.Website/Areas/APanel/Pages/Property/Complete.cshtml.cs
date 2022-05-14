using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.PropertyFeatures;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Application.PropertyLandMark;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Core.PropertyFeatures;
using Exwhyzee.Lojour.Core.PropertyImage;
using Exwhyzee.Lojour.Core.PropertyLandMarks;
using Exwhyzee.Lojour.Core.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]
    public class CompleteModel : PageModel
    {

        private readonly IPropertyAppService _propertyAppService;
        private readonly IPropertyFeaturesAppService _propertyFeaturesAppService;
        private readonly IPropertyLandMarkAppService _propertyLandMarkAppService;


        public CompleteModel(IPropertyAppService propertyAppService, IPropertyLandMarkAppService propertyLandMarkAppService,
            IPropertyFeaturesAppService propertyFeaturesAppService)
        {
            _propertyAppService = propertyAppService;
            _propertyLandMarkAppService = propertyLandMarkAppService;
            _propertyFeaturesAppService = propertyFeaturesAppService;

        }
        [BindProperty]
        public long FeatureId { get; set; }

        [BindProperty]
        public long LandMarkId { get; set; }

        [BindProperty]
        public PropertyFeature Feature { get; set; }

        [BindProperty]
        public PropertyLandMarks LandMark { get; set; }

        //
        public PagedList<PropertyFeature> ListFeatures { get; set; }


        public PagedList<PropertyLandMarks> ListLandMarks { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            var DataFeatures = await _propertyFeaturesAppService.GetAll(propertyId: id);
            ListFeatures = DataFeatures;

            //

            var DataLandMark = await _propertyLandMarkAppService.GetAll(propertyId: id);
            ListLandMarks = DataLandMark;

            return Page();
        }


        public async Task<IActionResult> OnPostFeatures(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new PropertyFeature
                {
                    Name = Feature.Name,
                    PropertyId = id

                };

                var newId = _propertyFeaturesAppService.Insert(item);




            }
            return RedirectToPage("./Complete", new { id = id });
        }


        public async Task<IActionResult> OnPostLandMark(long id)
        {
            if (ModelState.IsValid)
            {
                var item = new PropertyLandMarks
                {
                    Name = LandMark.Name,
                    LandMarkType = LandMark.LandMarkType,
                    Distance = LandMark.Distance,
                    PropertyId = id

                };

                var newId = _propertyLandMarkAppService.Insert(item);




            }
            return RedirectToPage("./Complete", new { id = id });


        }

        ///delete

        public async Task<IActionResult> OnPostLandMarkDelete(long id)
        {
            try
            {
                await _propertyLandMarkAppService.Delete(Id: LandMarkId);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./Complete", new { id = id });


        }

        public async Task<IActionResult> OnPostFeatureDelete(long id)
        {
            try
            {
                await _propertyFeaturesAppService.Delete(Id: FeatureId);

            }
            catch (Exception e)
            {

            }
            return RedirectToPage("./Complete", new { id = id });


        }

        //public async Task<IActionResult> OnPostAsync(long id)
        //{


        //    var property = await _propertyAppService.Get(id);
        //    if (property == null)
        //    {
        //        return NotFound($"Unable to load Raffle with the ID '{id}'.");
        //    }


        //    //raffle.Description = Raffle.Description;
        //    property.PropertyName = Data.PropertyName;
        //    property.Description = Data.Description;
        //    property.LandMark = Data.LandMark;
        //    property.Longitude = Data.Longitude;
        //    property.Latitude = Data.Latitude;
        //    property.Amount = Data.Amount;
        //    property.PropertyProfile = Data.PropertyProfile;
        //    property.PropertyStatus = Data.PropertyStatus;
        //    property.VerificationStatus = Data.VerificationStatus;
        //    property.PropertyAddress = Data.PropertyAddress;
        //    property.State = Data.State;
        //    property.LGA = Data.LGA;



        //    await _propertyAppService.Update(property);

        //    //
        //    #region property Image(s)
        //    int imgCount = 0;
        //    if (HttpContext.Request.Form.Files != null && HttpContext.Request.Form.Files.Count > 0)
        //    {
        //        var newFileName = string.Empty;
        //        var filePath = string.Empty;
        //        string pathdb = string.Empty;
        //        var files = HttpContext.Request.Form.Files;
        //        foreach (var file in files)
        //        {
        //            if (file.Length > 0)
        //            {
        //                filePath = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //                imgCount++;
        //                var now = DateTime.Now;
        //                var uniqueFileName = $"{now.Year}{now.Month}{now.Day}_{now.Hour}{now.Minute}{now.Second}{now.Millisecond}".Trim();




        //                var fileExtension = Path.GetExtension(filePath);

        //                newFileName = uniqueFileName + fileExtension;

        //                // if you wish to save file path to db use this filepath variable + newFileName
        //                var fileDbPathName = $"/PropertyImages/".Trim();

        //                filePath = $"{_hostingEnv.WebRootPath}{fileDbPathName}".Trim();

        //                if (!(Directory.Exists(filePath)))
        //                    Directory.CreateDirectory(filePath);

        //                var fileName = "";
        //                fileName = filePath + $"/{newFileName}".Trim();

        //                //Bitmap image = ResizeImage(file.OpenReadStream.file, 400, 800);
        //                // copy the file to the desired location from the tempMemoryLocation of IFile and flush temp memory
        //                using (FileStream fs = System.IO.File.Create(fileName))
        //                {
        //                    file.CopyTo(fs);
        //                    fs.Flush();
        //                }

        //                #region Save Image Propertie to Db
        //                var img = new PropertyImage()
        //                {
        //                    Url = $"{fileDbPathName}/{newFileName}",
        //                    ImageExtension = fileExtension,
        //                    DateCreated = DateTime.UtcNow.AddHours(1),
        //                    Status = Enums.EntityStatus.Active,
        //                    IsDefault = imgCount == 1 ? true : false,
        //                    PropertyId = property.Id
        //                };
        //                var saveImageToDb = await _propertyImagesAppService.Insert(img);

        //                #endregion

        //                if (imgCount >= 20)
        //                    break;
        //            }
        //        }
        //    }
        //    #endregion
        //    //StatusMessage = "The Selected Raffle has been updated";
        //    return RedirectToPage("./Index");
        //}

    }
}