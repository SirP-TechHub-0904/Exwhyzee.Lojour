using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Enums;
using Exwhyzee.Lojour.Core.EstateProperties;
using Exwhyzee.Lojour.Core.RequestProperties;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.RequestProperties
{
    public class RequestPropertyRepository : IRequestPropertyRepository
    {
        #region Const

        private const string CACHE_REQUESTPROPERTY = "exwhyzee.lojour.REQUESTPROPERTY";
        private const int CACHE_EXPIRATION_MINUTES = 30;

        #endregion

        #region Fields

        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public RequestPropertyRepository(
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

        public async Task<long> Add(RequestProperty entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                   
                    var sql = $"dbo.spInsertRequestProperty @propertyName,@phoneNumber,@email,@listType,@category,@location,@landMark,@features,@amountRange,@alertType,@alertDuration,@dateCreated,@requestId";


                    entity.Id = conn.ExecuteScalar<int>(sql,
                        new
                        {


                            propertyName = entity.PropertyName,
                            phoneNumber = entity.PhoneNumber,
                            email = entity.Email,
                            listType = entity.ListType,
                            category = entity.Category,
                            location = entity.Location,
                            landMark = entity.LandMark,
                            features = entity.Features,
                            amountRange = entity.AmountRange,
                            alertType = entity.AlertType,
                            alertDuration = entity.AlertDuration,
                            dateCreated = entity.DateCreated,
                             requestId  = entity.RequestId


    },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                   
                    return entity;
                });

                _signal.SignalToken(CACHE_REQUESTPROPERTY);
                var item = await Get(entity.Id);
                item.RequestId = "LJ/RQ/" + entity.Id.ToString("00000");
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

                _signal.SignalToken(CACHE_REQUESTPROPERTY);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagedList<RequestProperty>> GetAsync(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            string cacheKey = $"{CACHE_REQUESTPROPERTY}.getallrequest.{status}.{dateStart}.{dateEnd}.{startIndex}.{count}.{searchString}";
            var entity = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTES);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_REQUESTPROPERTY));
                return _storage.UseConnection(conn =>
                {
                    string query = $"dbo.spListAllRequestProperty @status, @dateStart, @dateEnd, @startIndex, @count, @searchString";
                    var result = conn.Query<RequestProperty>(query, new
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
            var paggedResult = new PagedList<RequestProperty>(source: entity,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }


        public async Task<RequestProperty> Get(long id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            string cacheKey = $"{CACHE_REQUESTPROPERTY}.getbyidRequestProperty:{id}";
            var entity = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTES);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_REQUESTPROPERTY));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spGetByIdRequestProperty @id";
                    return conn.QueryFirstOrDefault<RequestProperty>(sql,
                        new { id },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS
                        );
                });
            });

            return await Task.FromResult(entity);
        }

        public async Task Update(RequestProperty entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                var sql = $"dbo.spUpdateRequestProperty @id,@propertyName,@phoneNumber,@email,@listType,@category,@location,@landMark,@features,@amountRange,@alertType,@alertDuration,@dateCreated,@requestId";

                    conn.Execute(sql,
                        new
                        {

                            id = entity.Id,
                            propertyName = entity.PropertyName,
                            phoneNumber = entity.PhoneNumber,
                            email = entity.Email,
                            listType = entity.ListType,
                            category = entity.Category,
                            location = entity.Location,
                            landMark = entity.LandMark,
                            features = entity.Features,
                            amountRange = entity.AmountRange,
                            alertType = entity.AlertType,
                            alertDuration = entity.AlertDuration,
                            dateCreated = entity.DateCreated,
                            requestId = entity.RequestId

                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;



                });

                _signal.SignalToken(CACHE_REQUESTPROPERTY);
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
