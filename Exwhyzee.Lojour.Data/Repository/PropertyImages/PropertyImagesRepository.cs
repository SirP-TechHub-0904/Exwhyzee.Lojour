using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Lojour.Core.PropertyImage;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.PropertyImages
{
    public class PropertyImagesRepository : IPropertyImagesRepository
    {
        #region constants
        private const string CACHE_PropertyImage = "Exwhyzee.Lojour.Data.propertyImage";
        private const int CACHE_EXPIRATION_MINUTE = 30;
        #endregion

        #region Fields
        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public PropertyImagesRepository(IStorage storage, IMemoryCache memoryCache, ISignal signal, IClock clock)
        {
            _storage = storage;
            _memoryCache = memoryCache;
            _signal = signal;
            _clock = clock;
        }

        public async Task<long> Insert(PropertyImage img)
        {
            try
            {
                if (img == null)
                    throw new ArgumentNullException(nameof(img), "Model cannot be null");

                img = _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spInsertPropertyImage @url,@propertyId,@dateCreated,@imageExtension,@status,@isDefault";
                    img.Id = conn.ExecuteScalar<long>(sql, new
                    {
                        img.Url,
                        img.PropertyId,
                        img.DateCreated,
                        img.ImageExtension,
                        img.Status,
                        img.IsDefault
                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                    return img;
                });
                _signal.SignalToken(CACHE_PropertyImage);
                return await Task.FromResult(img.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Upate(PropertyImage img)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));

            img = _storage.UseConnection(conn =>
            {
                string sql = "spUpdatePropertyImage @id,@url,@propertyId,@dateCreated,@imageExtension,@status,@isDefault";
                conn.Execute(sql, new
                {
                    img.Id,
                    img.Url,
                    img.PropertyId,
                    img.DateCreated,
                    img.ImageExtension,
                    img.Status,
                    img.IsDefault
                    
                }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                return img;
            });

            _signal.SignalToken(CACHE_PropertyImage);
            await Task.CompletedTask;
        }

        public async Task Delete(long Id)
        {

            var imgg = await GetById(Id);
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            var model = _storage.UseConnection(conn =>
            {
                string sql = "spDeletePropertyImage @Id";
                conn.Execute(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                return true;
            });

            _signal.SignalToken(CACHE_PropertyImage);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgg.Url);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            await Task.CompletedTask;
        }

        public async Task<PropertyImage> GetById(long Id)
        {
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            string cacheKey = $"{CACHE_PropertyImage}.getById.{Id}";
            var image = _memoryCache.GetOrCreate(cacheKey, (entry) => {

                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_PropertyImage));
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);

                return _storage.UseConnection(conn =>
                {
                    string sql = $"[dbo].[spGetByIdPropertyImage] @id";
                    return conn.QueryFirstOrDefault<PropertyImage>(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                });
            });
            return await Task.FromResult(image);
        }

        //TODO: This should be in mapImagesToRaffle
        public Task<IEnumerable<PropertyImage>> GetImagesOfARaffle(long reffleId)
        {
            return null;
        }

        public async Task<PagedList<PropertyImage>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0)
        {

            string cacheKey = $"{CACHE_PropertyImage}.GetAsyncAllimages.{propertyId}.{count}.{dateStart}";
            var img = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_PropertyImage));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spListAllPropertyImage @dateStart,@dateEnd, @startIndex, @count, @searchString, @propertyId";



                    var result = conn.Query<PropertyImage>(sql, new
                    {
                       
                        dateStart = dateStart,
                        dateEnd = dateEnd,
                        startIndex = startIndex,
                        count = count,
                        searchString = searchString,
                        propertyId = propertyId
                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return result;
                });
            });

            var filterCount = img.AsList().Count;
            var paggedResult = new PagedList<PropertyImage>(source: img,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        public Task<IEnumerable<PropertyImage>> GetPropertyImages(long propertyId)
        {
            throw new NotImplementedException();
        }

        //public Task<PagedList<PropertyImage>> GetAsyncAll(string extension = null, DateTime? dateStart = null, DateTime? dateStop = null, int startIndex = 0, int count = int.MaxValue)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion

    }
}
