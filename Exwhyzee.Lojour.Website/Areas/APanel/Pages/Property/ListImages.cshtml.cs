using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.EstateProperties.Dto;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Application.PropertyImages.Dto;
using Exwhyzee.Lojour.Core.EstateProperties;
using Exwhyzee.Lojour.Core.PropertyImage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exwhyzee.Lojour.Website.Areas.APanel.Pages.Property
{
    [Authorize(Roles = "SuperAdmin,Agent,Admin")]

    public class ListImagesModel : PageModel
    {
        private readonly IPropertyImagesAppService _propertyImagesAppService;
private readonly IPropertyAppService _propertyAppService;
        private readonly IHostingEnvironment _hostingEnv;

        public ListImagesModel(IPropertyImagesAppService propertyImagesAppService, 
            IHostingEnvironment env, IPropertyAppService propertyAppService)
        {
            _propertyImagesAppService = propertyImagesAppService;
            _propertyAppService = propertyAppService;
            _hostingEnv = env;
        }

        [BindProperty]
        public EstatePropertyDto Data { get; set; }

        [BindProperty]
        public long Propertyid { get; set; }

        [BindProperty]
        public long PropertyId { get; set; }

        public PagedList<PropertyImageDto> PropertyImage { get; set; }
        List<PropertyImageDto> imageproperty = new List<PropertyImageDto>();

        public async Task<IActionResult> OnGetAsync(long id)
        {
            var paggedProperty = await _propertyImagesAppService.GetAllImages(propertyId: id);
            var paggedSource = paggedProperty.Source.ToList();


            imageproperty.AddRange(paggedSource.Select(entity => new PropertyImageDto()
            {
               
                Id = entity.Id,
                IsDefault = entity.IsDefault,
                Status = entity.Status,
                Url = entity.Url

            }));
            try
            {
                Propertyid = id;
            }catch(Exception c)
            {

            }
            PropertyImage = new PagedList<PropertyImageDto>(source: imageproperty, pageIndex: paggedProperty.PageIndex,
                                           pageSize: paggedProperty.PageSize, filteredCount: paggedProperty.FilteredCount, totalCount:
                                           paggedProperty.TotalCount);

            var item = await _propertyAppService.Get(id);
            Data = item;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                if (ModelState.IsValid)
                {
                   
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
                                    PropertyId = Propertyid
                                };
                                var saveImageToDb = await _propertyImagesAppService.Insert(img);

                                #endregion

                                if (imgCount >= 20)
                                    break;
                            }
                        }
                    }
                    #endregion

                    return RedirectToPage("ListImages");
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