using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Core.PropertyImage;
using Exwhyzee.Lojour.Core.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exwhyzee.Lojour.Web.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]

    public class FormModel : PageModel
    {

        private readonly IPropertyAppService _propertyAppService;
        private readonly IPropertyImagesAppService _propertyImagesAppService;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IStateAppService _stateAppService;

        public FormModel(IPropertyAppService propertyAppService, IHostingEnvironment env,
            IPropertyImagesAppService propertyImagesAppService, IStateAppService stateAppService)
        {
            _propertyAppService = propertyAppService;
            _hostingEnv = env;
            _propertyImagesAppService = propertyImagesAppService;
            _stateAppService = stateAppService;
        }

        [BindProperty]
        public EstatePropertyDto Data { get; set; }


        public List<StateModel> State { get; set; }
        public async Task<IActionResult> OnGetAsync(long id)
        {


            var item = await _propertyAppService.Get(id);

            string imageUrl = "";
            if (item == null)
            {
                return NotFound($"Unable to load raffle with the ID '{id}'.");
            }


            Data = new EstatePropertyDto
            {

                PropertyName = item.PropertyName,
                Description = item.Description,
                AgentDetails = item.AgentDetails,
                Longitude = item.Longitude,
                Latitude = item.Latitude,
                Amount = item.Amount,
                PropertyProfile = item.PropertyProfile,
                PropertyStatus = item.PropertyStatus,
                VerificationStatus = item.VerificationStatus,
                PropertyAddress = item.PropertyAddress,
                State = item.State,
                LGA = item.LGA,
                Video = item.Video,
                MapLink = item.MapLink,
                Id = item.Id


            };
            //state

            var StateData = await _stateAppService.GetAll();
            var StateSource = StateData.Source.ToList();

            State = StateSource.ToList();


            return Page();
        }


        public async Task<IActionResult> OnPostAsync(long id)
        {


            var property = await _propertyAppService.Get(id);
            if (property == null)
            {
                return NotFound($"Unable to load Raffle with the ID '{id}'.");
            }


            //raffle.Description = Raffle.Description;
            property.PropertyName = Data.PropertyName;
            property.Description = Data.Description;
            property.AgentDetails = Data.AgentDetails;
            property.Longitude = Data.Longitude;
            property.Latitude = Data.Latitude;
            property.Amount = Data.Amount;
            property.PropertyProfile = Data.PropertyProfile;
            property.PropertyStatus = Data.PropertyStatus;
            property.VerificationStatus = Data.VerificationStatus;
            property.PropertyAddress = Data.PropertyAddress;
            property.State = Data.State;
            property.LGA = Data.LGA;
            property.Video = Data.Video;
            property.MapLink = Data.MapLink;
            property.IdentificationNumber = "LJ/" + property.Id.ToString("00000");
            


            await _propertyAppService.Update(property);

            //
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
                            PropertyId = property.Id
                        };
                        var saveImageToDb = await _propertyImagesAppService.Insert(img);

                        #endregion

                        if (imgCount >= 20)
                            break;
                    }
                }
            }
            #endregion
            //StatusMessage = "The Selected Raffle has been updated";
            return RedirectToPage("./Complete", new { id = property.Id });
        }

    }
}