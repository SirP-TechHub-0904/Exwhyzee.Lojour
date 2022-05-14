using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Lojour.Core.DegreeObtained;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.DegreeObtained
{
   public class DegreeObtainedRepository : IDegreeObtainedRepository
    {
        #region constants
        private const string CACHE_DegreeObtained = "Exwhyzee.Lojour.Data.DegreeObtained";
        private const int CACHE_EXPIRATION_MINUTE = 30;
        #endregion

        #region Fields
        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public DegreeObtainedRepository(IStorage storage, IMemoryCache memoryCache, ISignal signal, IClock clock)
        {
            _storage = storage;
            _memoryCache = memoryCache;
            _signal = signal;
            _clock = clock;
        }

         public async Task<long> Insert(DegreeObtainedModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                   
                    var sql = $"dbo.spInsertDegreeObtained @title,@abbr,@date,@userProfileId";


                    entity.Id = conn.ExecuteScalar<int>(sql,
                        new
                        {

                            title = entity.Title,
                            abbr = entity.Abbr,
                            date = entity.Date,
                            userProfileId = entity.UserProfileId
                           

                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;
                });

                _signal.SignalToken(CACHE_DegreeObtained);
              
                return await Task.FromResult(entity.Id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex}");
            }
        }

        public async Task Delete(long Id)
        {
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            var model = _storage.UseConnection(conn =>
            {
                string sql = "spDeleteDegreeObtained @Id";
                conn.Execute(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                return true;
            });

            _signal.SignalToken(CACHE_DegreeObtained);
            await Task.CompletedTask;
        }

        public async Task<DegreeObtainedModel> GetById(long Id)
        {
            _signal.SignalToken(CACHE_DegreeObtained);
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            string cacheKey = $"{CACHE_DegreeObtained}.getByIdDegreeObtained.{Id}";
            var image = _memoryCache.GetOrCreate(cacheKey, (entry) => {

                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_DegreeObtained));
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);

                return _storage.UseConnection(conn =>
                {
                    string sql = $"[dbo].spGetByIdDegreeObtained @id";
                    return conn.QueryFirstOrDefault<DegreeObtainedModel>(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                });
            });
            return await Task.FromResult(image);
        }


        public async Task<PagedList<DegreeObtainedModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            _signal.SignalToken(CACHE_DegreeObtained);

            string cacheKey = $"{CACHE_DegreeObtained}.GetAsyncDegreeObtained.{count}.{dateStart}";
            var img = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_DegreeObtained));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spListAllDegreeObtained @dateStart,@dateEnd, @startIndex, @count, @searchString, @userProfileId";



                    var result = conn.Query<DegreeObtainedModel>(sql, new
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
            var paggedResult = new PagedList<DegreeObtainedModel>(source: img,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }

        public async Task Update(DegreeObtainedModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                    var sql = $"dbo.spUpdateDegreeObtained @id,@title,@abbr,@date,@userProfileId";

                    conn.Execute(sql,
                        new
                        {

                            id = entity.Id,
                            title = entity.Title,
                            abbr = entity.Abbr,
                            date = entity.Date,
                            userProfileId = entity.UserProfileId



                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;



                });

                _signal.SignalToken(CACHE_DegreeObtained);
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

      

        //public Task<PagedList<DegreeObtained>> GetAsyncAll(string extension = null, DateTime? dateStart = null, DateTime? dateStop = null, int startIndex = 0, int count = int.MaxValue)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
