using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Enums;
using Exwhyzee.Lojour.Core.EstateProperties;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.EstateProperties
{
    public class PropertyRepository: IPropertyRepository
    {
        #region Const

        private const string CACHE_ESTATEPROPERTY = "exwhyzee.lojour.category";
        private const int CACHE_EXPIRATION_MINUTES = 30;

        #endregion

        #region Fields

        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public PropertyRepository(
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

        public async Task<long> Add(EstateProperty entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                   
                    var sql = $"dbo.spInsertProperty @propertName,@description,@agentDetails,@longitude,@latitude,@amount," +
                    $"@propertyProfile,@propertyType,@propertyStatus,@verificationStatus,@descriptiveStatus,@propertyAddress,@dateCreated,@identificationNumber,@state,@lga,@community," +
                    $"@kindred,@sortOrder,@homeLocation,@username,@video,@propertyLevel,@mapLink";


                    entity.Id = conn.ExecuteScalar<int>(sql,
                        new
                        {

                            propertName = entity.PropertyName,
                            description = entity.Description,
                            agentDetails = entity.AgentDetails,
                            longitude = entity.Longitude,
                            latitude = entity.Latitude,
                            amount = entity.Amount,
                            propertyProfile = entity.PropertyProfile,
                            propertyType = entity.PropertyType,
                            propertyStatus = entity.PropertyStatus,
                            verificationStatus = entity.VerificationStatus,
                            descriptiveStatus = entity.DescriptiveStatus,
                            propertyAddress = entity.PropertyAddress,
                            dateCreated = entity.DateCreated,
                            identificationNumber = entity.IdentificationNumber,
                            state = entity.State,
                            lga = entity.LGA,
                            community = entity.Community,
                            kindred = entity.Kindred,
                            SortOrder = entity.SortOrder,
                            homeLocation = entity.HomeLocation,
                            username = entity.Username,
                            video = entity.Video,
                            propertyLevel = entity.PropertyLevel,
                            mapLink = entity.MapLink

                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;
                });

                _signal.SignalToken(CACHE_ESTATEPROPERTY);
                var item = await Get(entity.Id);
                item.IdentificationNumber = "LJ/" + entity.Id.ToString("000000");
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

                entity.PropertyStatus = PropertyStatus.Delete;
                await Update(entity);

                _signal.SignalToken(CACHE_ESTATEPROPERTY);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PagedList<EstateProperty>> GetAsync(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, string username = null, int? descriptiveStatus = null, int? propertyStatus = null)
        {
            string cacheKey = $"{CACHE_ESTATEPROPERTY}.getall.{status}.{dateStart}.{dateEnd}.{startIndex}.{count}.{searchString}new";
            var entity = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTES);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_ESTATEPROPERTY));
                return _storage.UseConnection(conn =>
                {
                    string query = $"dbo.spListAllProperties @status, @dateStart, @dateEnd, @startIndex, @count, @searchString, @username,@descriptiveStatus,@propertyStatus";
                    var result = conn.Query<EstateProperty>(query, new
                    {
                        status = status,
                        dateStart = dateStart,
                        dateEnd = dateEnd,
                        startIndex = startIndex,
                        count = count,
                        searchString = searchString,
                        username = username,
                        descriptiveStatus = descriptiveStatus,
                        propertyStatus = propertyStatus
                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return result;
                });
            });

            var filterCount = entity.AsList().Count;
            var paggedResult = new PagedList<EstateProperty>(source: entity,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }

        public async Task<PagedList<EstateProperty>> GetAsyncByUserId(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, string username = null)
        {
            string cacheKey = $"{CACHE_ESTATEPROPERTY}.spListAllPropertiesByUserId.{status}.{dateStart}.{dateEnd}.{startIndex}.{count}.{searchString}";
            var entity = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTES);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_ESTATEPROPERTY));
                return _storage.UseConnection(conn =>
                {
                    string query = $"dbo.spListAllPropertiesByUserId @status, @dateStart, @dateEnd, @startIndex, @count, @searchString, @username";
                    var result = conn.Query<EstateProperty>(query, new
                    {
                        status = status,
                        dateStart = dateStart,
                        dateEnd = dateEnd,
                        startIndex = startIndex,
                        count = count,
                        searchString = searchString,
                        username = username
                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return result;
                });
            });

            var filterCount = entity.AsList().Count;
            var paggedResult = new PagedList<EstateProperty>(source: entity,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);
            _signal.SignalToken(CACHE_ESTATEPROPERTY);
            return await Task.FromResult(paggedResult);
        }



        public async Task<EstateProperty> Get(long id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            string cacheKey = $"{CACHE_ESTATEPROPERTY}.getbyid:{id}";
            var entity = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTES);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_ESTATEPROPERTY));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spGetByIdProperty @id";
                    return conn.QueryFirstOrDefault<EstateProperty>(sql,
                        new { id },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS
                        );
                });
            });

            return await Task.FromResult(entity);
        }

        public async Task Update(EstateProperty entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                var sql = $"dbo.spUpdateProperty @id,@propertyName,@description,@agentDetails,@longitude,@latitude,@amount," +
                $"@propertyProfile,@propertyType,@propertyStatus,@verificationStatus,@descriptiveStatus,@propertyAddress,@dateCreated,@identificationNumber," +
                $"@state,@lga,@community,@kindred,@sortOrder,@homeLocation,@username,@video,@propertyLevel,@mapLink";

                    conn.Execute(sql,
                        new
                        {

                            id = entity.Id,
                            propertyName = entity.PropertyName,
                            description = entity.Description,
                            agentDetails = entity.AgentDetails,
                            longitude = entity.Longitude,
                            latitude = entity.Latitude,
                            amount = entity.Amount,
                            propertyProfile = entity.PropertyProfile,
                            propertyType = entity.PropertyType,
                            propertyStatus = entity.PropertyStatus,
                            verificationStatus = entity.VerificationStatus,
                            descriptiveStatus = entity.DescriptiveStatus,
                            propertyAddress = entity.PropertyAddress,
                            dateCreated = entity.DateCreated,
                            identificationNumber = entity.IdentificationNumber,
                            state = entity.State,
                            lga = entity.LGA,
                            community = entity.Community,
                            kindred = entity.Kindred,
                            sortOrder = entity.SortOrder,
                            homeLocation = entity.HomeLocation,
                            username = entity.Username,
                            video = entity.Video,
                            propertyLevel = entity.PropertyLevel,
                            mapLink = entity.MapLink

                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;



                });

                _signal.SignalToken(CACHE_ESTATEPROPERTY);
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

        public async Task<PagedList<EstateProperty>> GetAsyncByRatingAndBidding(int? status = null, DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            string cacheKey = $"{CACHE_ESTATEPROPERTY}.GetAsyncByRatingAndBidding.{status}.{dateStart}.{dateEnd}.{startIndex}.{count}.{searchString}";
            var entity = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTES);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_ESTATEPROPERTY));
                return _storage.UseConnection(conn =>
                {
                    string query = $"dbo.spListAllPropertiesWithRatingAndBidding @status, @dateStart, @dateEnd, @startIndex, @count, @searchString";
                    var result = conn.Query<EstateProperty>(query, new
                    {
                        status = status,
                        dateStart = dateStart,
                        dateEnd = dateEnd,
                        startIndex = startIndex,
                        count = count,
                        searchString = searchString,
                    }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return result;
                });
            });

            var filterCount = entity.AsList().Count;
            var paggedResult = new PagedList<EstateProperty>(source: entity,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }
        #endregion

    }
}
