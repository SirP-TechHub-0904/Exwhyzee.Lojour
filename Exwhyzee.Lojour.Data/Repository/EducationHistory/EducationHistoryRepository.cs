using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Lojour.Core.EducationHistory;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.EducationHistory
{
   public class EducationHistoryRepository : IEducationHistoryRepository
    {
        #region constants
        private const string CACHE_EducationHistory = "Exwhyzee.Lojour.Data.EducationHistory";
        private const int CACHE_EXPIRATION_MINUTE = 30;
        #endregion

        #region Fields
        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public EducationHistoryRepository(IStorage storage, IMemoryCache memoryCache, ISignal signal, IClock clock)
        {
            _storage = storage;
            _memoryCache = memoryCache;
            _signal = signal;
            _clock = clock;
        }

         public async Task<long> Insert(EducationHistoryModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                   
                    var sql = $"dbo.spInsertEducationHistory @schoolAttended,@course,@startDate,@endDate,@grade,@isCurrent,@userProfileId";


                    entity.Id = conn.ExecuteScalar<int>(sql,
                        new
                        {

                            schoolAttended = entity.SchoolAttended,
                            course = entity.Course,
                            startDate = entity.StartDate,
                            endDate = entity.EndDate,
                            grade = entity.Grade,
                            isCurrent = entity.IsCurrent,
                            userProfileId = entity.UserProfileId
                           

                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;
                });

                _signal.SignalToken(CACHE_EducationHistory);
              
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
                string sql = "spDeleteEducationHistory @Id";
                conn.Execute(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                return true;
            });

            _signal.SignalToken(CACHE_EducationHistory);
            await Task.CompletedTask;
        }

        public async Task<EducationHistoryModel> GetById(long Id)
        {
            _signal.SignalToken(CACHE_EducationHistory);
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            string cacheKey = $"{CACHE_EducationHistory}.getByIdEducationHistory.{Id}";
            var image = _memoryCache.GetOrCreate(cacheKey, (entry) => {

                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_EducationHistory));
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);

                return _storage.UseConnection(conn =>
                {
                    string sql = $"[dbo].spGetByIdEducationHistory @id";
                    return conn.QueryFirstOrDefault<EducationHistoryModel>(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                });
            });
            return await Task.FromResult(image);
        }


        public async Task<PagedList<EducationHistoryModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? userProfileId = null)
        {
            _signal.SignalToken(CACHE_EducationHistory);

            string cacheKey = $"{CACHE_EducationHistory}.GetAsyncEducationHistory.{count}.{dateStart}";
            var img = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_EducationHistory));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spListAllEducationHistory @dateStart,@dateEnd, @startIndex, @count, @searchString, @userProfileId";



                    var result = conn.Query<EducationHistoryModel>(sql, new
                    {

                        dateStart = dateStart,
                        dateEnd = dateEnd,
                        startIndex = startIndex,
                        count = count,
                        searchString = searchString,
                        userProfileId = userProfileId

                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return result;
                });
            });

            var filterCount = img.AsList().Count;
            var paggedResult = new PagedList<EducationHistoryModel>(source: img,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }

        public async Task Update(EducationHistoryModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                    var sql = $"dbo.spUpdateEducationHistory @id,@schoolAttended,@course,@startDate,@endDate,@grade,@isCurrent,@userProfileId";

                    conn.Execute(sql,
                        new
                        {

                            id = entity.Id,
                            schoolAttended = entity.SchoolAttended,
                            course = entity.Course,
                            startDate = entity.StartDate,
                            endDate = entity.EndDate,
                            grade = entity.Grade,
                            isCurrent = entity.IsCurrent,
                            userProfileId = entity.UserProfileId



                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;



                });

                _signal.SignalToken(CACHE_EducationHistory);
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

      

        //public Task<PagedList<EducationHistory>> GetAsyncAll(string extension = null, DateTime? dateStart = null, DateTime? dateStop = null, int startIndex = 0, int count = int.MaxValue)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
