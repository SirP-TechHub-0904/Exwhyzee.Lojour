
using Exwhyzee.Lojour.Application.Pages.Dto;
using Exwhyzee.Lojour.Core.Page;
using Exwhyzee.Lojour.Data.Repository.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Application.Pages
{
    public class PageAppService: IPageAppService
    {
        private readonly IPageRepository _pageRepository;
       

        public PageAppService(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }



        public async Task<long> Add(PageData entity)
        {
           

            return await _pageRepository.Insert(entity);
        }

        public async Task Delete(long id)
        {
            await _pageRepository.Delete(id);
        }

        public async Task<PageDataDto> Get(long id)
        {
            var entity = await _pageRepository.GetById(id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var data = new PageDataDto
            {
                Title = entity.Title,
                Content = entity.Content,
                Id =  entity.Id,
                PagePosition = entity.PagePosition,
                PageStatus = entity.PageStatus
               
            };



            return data;
        }

        public async Task<PagedList<PageData>> GetAllPages(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            List<PageData> dataitem = new List<PageData>();
            var paggedData = await _pageRepository.GetAsyncAll(dateStart, dateEnd, startIndex, count, searchString);

            var paggedSource = paggedData.Source.ToList();


            dataitem.AddRange(paggedSource.Select(entity => new PageData()
            {
                Title = entity.Title,
                PageStatus = entity.PageStatus,
                Content = entity.Content,
                PagePosition = entity.PagePosition,
                Id = entity.Id
                
            }));

            return new PagedList<PageData>(source: dataitem, pageIndex: paggedData.PageIndex,
                                            pageSize: paggedData.PageSize, filteredCount: paggedData.FilteredCount, totalCount:
                                            paggedData.TotalCount);

        }



        public async Task Update(PageDataDto entity)
        {
            try
            {
               var Data = new PageData
                {
                   Id = entity.Id,
                    Title = entity.Title,
                    PageStatus = entity.PageStatus,
                    Content = entity.Content,
                    PagePosition = entity.PagePosition
                };

                await _pageRepository.Update(Data);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
