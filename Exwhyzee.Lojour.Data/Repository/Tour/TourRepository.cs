using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Enums;
using Exwhyzee.Lojour.Core.Tour;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.Tour
{
    public class TourRepository : ITourRepository
    {
        #region Const

        private const string CACHE_TOUR = "exwhyzee.lojour.Tour";
        private const int CACHE_EXPIRATION_MINUTES = 30;

        #endregion

        #region Fields

        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public TourRepository(
            IStorage storage,
            IMemoryCache memoryCache,
            ISignal signal,
            IClock clock)
        {
            _storage = storage;
            _memoryCache = memoryCache;
            _signal = signal;
            _clock = clock;
        }
        #endregion

        #region Methods

        public async Task<long> Add(TourModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                   
                    var sql = $"dbo.spInsertTour @phoneNumber,@email,@date,@time,@payment,@fullName,@tourId";


                    entity.Id = conn.ExecuteScalar<int>(sql,
                        new
                        {

                            phoneNumber = entity.PhoneNumber,
                            email = entity.Email,
                            date = entity.Date,
                            time = entity.Time,
                            payment = entity.Payment,
                            fullName = entity.FullName,
                            tourId = entity.TourId

    },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                   
                    return entity;
                });

                _signal.SignalToken(CACHE_TOUR);
                var item = await Get(entity.Id);
                item.TourId = "LJ/TOUR/" + entity.Id.ToString("00000");
                await Update(item);
                return await Task.FromResult(entity.Id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex}");
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentNullException(nameof(id));

                var entity = await Get(id);

                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                
                await Delete(id);

                _signal.SignalToken(CACHE_TOUR);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagedList<TourModel>> GetAsync(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            string cacheKey = $"{CACHE_TOUR}.getalltour.{status}.{dateStart}.{dateEnd}.{startIndex}.{count}.{searchString}";
            var entity = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTES);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_TOUR));
                return _storage.UseConnection(conn =>
                {
                    string query = $"dbo.spListAllTour @status, @dateStart, @dateEnd, @startIndex, @count, @searchString";
                    var result = conn.Query<TourModel>(query, new
                    {
                        status = status,
                        dateStart = dateStart,
                        dateEnd = dateEnd,
                        startIndex = startIndex,
                        count = count,
                        searchString = searchString
                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return result;
                });
            });

            var filterCount = entity.AsList().Count;
            var paggedResult = new PagedList<TourModel>(source: entity,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }


        public async Task<TourModel> Get(long id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            string cacheKey = $"{CACHE_TOUR}.getbyidTOUR:{id}";
            var entity = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTES);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_TOUR));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spGetByIdTour @id";
                    return conn.QueryFirstOrDefault<TourModel>(sql,
                        new { id },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS
                        );
                });
            });

            return await Task.FromResult(entity);
        }

        public async Task Update(TourModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                var sql = $"dbo.spUpdateTour @id,@phoneNumber,@email,@date,@time,@payment,@fullName,@tourId";

                    conn.Execute(sql,
                        new
                        {

                            id = entity.Id,
                            phoneNumber = entity.PhoneNumber,
                            email = entity.Email,
                            date = entity.Date,
                            time = entity.Time,
                            payment = entity.Payment,
                            fullName = entity.FullName,
                            tourId = entity.TourId

                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;



                });

                _signal.SignalToken(CACHE_TOUR);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex}");
            }
        }

        #endregion
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

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
