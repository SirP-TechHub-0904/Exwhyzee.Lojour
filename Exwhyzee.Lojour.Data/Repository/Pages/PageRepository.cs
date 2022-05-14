using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Lojour.Core.Page;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Pages
{
   public class PageRepository : IPageRepository
    {
        #region constants
        private const string CACHE_PAGE = "Exwhyzee.Lojour.Data.PageData";
        private const int CACHE_EXPIRATION_MINUTE = 30;
        #endregion

        #region Fields
        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public PageRepository(IStorage storage, IMemoryCache memoryCache, ISignal signal, IClock clock)
        {
            _storage = storage;
            _memoryCache = memoryCache;
            _signal = signal;
            _clock = clock;
        }

        public async Task<long> Insert(PageData item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item), "Model cannot be null");

                item = _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spInsertPage @title,@pageStatus,@content,@pagePosition";
                    item.Id = conn.ExecuteScalar<long>(sql, new
                    {
                        item.Title,
                        item.PageStatus,
                        item.Content,
                        item.PagePosition
                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                    return item;
                });
                _signal.SignalToken(CACHE_PAGE);
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
                string sql = "spDeletePage @Id";
                conn.Execute(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                return true;
            });

            _signal.SignalToken(CACHE_PAGE);
            await Task.CompletedTask;
        }

        public async Task<PageData> GetById(long Id)
        {
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            string cacheKey = $"{CACHE_PAGE}.getByIdPages.{Id}";
            var data = _memoryCache.GetOrCreate(cacheKey, (entry) => {

                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_PAGE));
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);

                return _storage.UseConnection(conn =>
                {
                    string sql = $"[dbo].[spGetByIdPage] @id";
                    return conn.QueryFirstOrDefault<PageData>(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                });
            });
            return await Task.FromResult(data);
        }


        public async Task<PagedList<PageData>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {

            string cacheKey = $"{CACHE_PAGE}.GetAsyncpage.{count}.{dateStart}";
            var img = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_PAGE));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spListAllPage @dateStart,@dateEnd, @startIndex, @count, @searchString";



                    var result = conn.Query<PageData>(sql, new
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
            var paggedResult = new PagedList<PageData>(source: img,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }


        public async Task Update(PageData entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                    var sql = $"dbo.spUpdatePage @id,@title,@pageStatus,@content,@pagePosition";

                    conn.Execute(sql,
                        new
                        {

                            id = entity.Id,
                            title = entity.Title,
                            pageStatus = entity.PageStatus,
                            content = entity.Content,
                            pagePosition = entity.PagePosition


                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;



                });

                _signal.SignalToken(CACHE_PAGE);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex}");
            }
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



       
        #endregion
        #endregion
    }
}
