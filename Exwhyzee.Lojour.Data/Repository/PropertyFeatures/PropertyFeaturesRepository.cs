using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Lojour.Core.PropertyFeatures;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.PropertyFeatures
{
   public class PropertyFeaturesRepository : IPropertyFeaturesRepository
    {
        #region constants
        private const string CACHE_PropertyFeature = "Exwhyzee.Lojour.Data.PropertyFeatures";
        private const int CACHE_EXPIRATION_MINUTE = 30;
        #endregion

        #region Fields
        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public PropertyFeaturesRepository(IStorage storage, IMemoryCache memoryCache, ISignal signal, IClock clock)
        {
            _storage = storage;
            _memoryCache = memoryCache;
            _signal = signal;
            _clock = clock;
        }

        public async Task<long> Insert(PropertyFeature item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item), "Model cannot be null");

                item = _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spInsertPropertyFeatures @name,@propertyId";
                    item.Id = conn.ExecuteScalar<long>(sql, new
                    {
                        item.Name,
                        item.PropertyId
                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                    return item;
                });
                _signal.SignalToken(CACHE_PropertyFeature);
                return await Task.FromResult(item.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task Delete(long Id)
        {
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            var model = _storage.UseConnection(conn =>
            {
                string sql = "spDeletePropertyFeatures @Id";
                conn.Execute(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                return true;
            });

            _signal.SignalToken(CACHE_PropertyFeature);
            await Task.CompletedTask;
        }

        public async Task<PropertyFeature> GetById(long Id)
        {
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            string cacheKey = $"{CACHE_PropertyFeature}.getByIdPropertyFeature.{Id}";
            var data = _memoryCache.GetOrCreate(cacheKey, (entry) => {

                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_PropertyFeature));
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);

                return _storage.UseConnection(conn =>
                {
                    string sql = $"[dbo].[spGetByIdPropertyFeatures] @id";
                    return conn.QueryFirstOrDefault<PropertyFeature>(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                });
            });
            return await Task.FromResult(data);
        }


        public async Task<PagedList<PropertyFeature>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long propertyId = 0)
        {

            string cacheKey = $"{CACHE_PropertyFeature}.GetAsyncPropertyFeature.{count}.{dateStart}";
            var img = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_PropertyFeature));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spListAllPropertyFeatures @dateStart,@dateEnd, @startIndex, @count, @searchString, @propertyId";



                    var result = conn.Query<PropertyFeature>(sql, new
                    {

                        dateStart = dateStart,
                        dateEnd = dateEnd,
                        startIndex = startIndex,
                        count = count,
                        searchString = searchString,
                        propertyId = propertyId

                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                    _signal.SignalToken(CACHE_PropertyFeature);
                    return result;
                });
            });

            var filterCount = img.AsList().Count;
            var paggedResult = new PagedList<PropertyFeature>(source: img,
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



        //public Task<PagedList<PropertyFeature>> GetAsyncAll(string extension = null, DateTime? dateStart = null, DateTime? dateStop = null, int startIndex = 0, int count = int.MaxValue)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
