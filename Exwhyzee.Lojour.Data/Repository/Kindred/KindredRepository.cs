using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Lojour.Core.KindredModel;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Kindred
{
   public class KindredRepository : IKindredRepository
    {
        #region constants
        private const string CACHE_Kindreds = "Exwhyzee.Lojour.Data.community";
        private const int CACHE_EXPIRATION_MINUTE = 30;
        #endregion

        #region Fields
        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public KindredRepository(IStorage storage, IMemoryCache memoryCache, ISignal signal, IClock clock)
        {
            _storage = storage;
            _memoryCache = memoryCache;
            _signal = signal;
            _clock = clock;
        }

        public async Task<long> Insert(Kindreds item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item), "Model cannot be null");

                item = _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spInsertKindred @name,@communityId";
                    item.Id = conn.ExecuteScalar<long>(sql, new
                    {
                        item.Name,
                        item.CommunityId
                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                    return item;
                });
                _signal.SignalToken(CACHE_Kindreds);
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
                string sql = "spDeleteKindred @Id";
                conn.Execute(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                return true;
            });

            _signal.SignalToken(CACHE_Kindreds);
            await Task.CompletedTask;
        }

        public async Task<Kindreds> GetById(long Id)
        {
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            string cacheKey = $"{CACHE_Kindreds}.getByIdKindreds.{Id}";
            var data = _memoryCache.GetOrCreate(cacheKey, (entry) => {

                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_Kindreds));
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);

                return _storage.UseConnection(conn =>
                {
                    string sql = $"[dbo].[spGetByIdKindred] @id";
                    return conn.QueryFirstOrDefault<Kindreds>(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                });
            });
            _signal.SignalToken(CACHE_Kindreds);

            return await Task.FromResult(data);
        }


        public async Task<PagedList<Kindreds>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {

            string cacheKey = $"{CACHE_Kindreds}.GetAsyncKindreds.{count}.{dateStart}";
            var img = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_Kindreds));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spListAllKindred @dateStart,@dateEnd, @startIndex, @count, @searchString";



                    var result = conn.Query<Kindreds>(sql, new
                    {

                        dateStart = dateStart,
                        dateEnd = dateEnd,
                        startIndex = startIndex,
                        count = count,
                        searchString = searchString

                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return result;
                });
            });

            var filterCount = img.AsList().Count;
            var paggedResult = new PagedList<Kindreds>(source: img,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);
            _signal.SignalToken(CACHE_Kindreds);

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



        //public Task<PagedList<Kindreds>> GetAsyncAll(string extension = null, DateTime? dateStart = null, DateTime? dateStop = null, int startIndex = 0, int count = int.MaxValue)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
