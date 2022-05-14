using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Lojour.Core.MeritCertificateFeature;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.MeritCertificateFeature
{
   public class MeritCertificateFeatureRepository : IMeritCertificateFeatureRepository
    {
        #region constants
        private const string CACHE_MeritCertificateFeature = "Exwhyzee.Lojour.Data.MeritCertificateFeature";
        private const int CACHE_EXPIRATION_MINUTE = 30;
        #endregion

        #region Fields
        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public MeritCertificateFeatureRepository(IStorage storage, IMemoryCache memoryCache, ISignal signal, IClock clock)
        {
            _storage = storage;
            _memoryCache = memoryCache;
            _signal = signal;
            _clock = clock;
        }

         public async Task<long> Insert(MeritCertificateFeatureModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                   
                    var sql = $"dbo.spInsertMeritCertificateFeature @feature,@meritCertificateId";


                    entity.Id = conn.ExecuteScalar<int>(sql,
                        new
                        {

                            Feature = entity.Feature,
                            meritCertificateId = entity.MeritCertificateId
                           

                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;
                });

                _signal.SignalToken(CACHE_MeritCertificateFeature);
              
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
                string sql = "spDeleteMeritCertificateFeature @Id";
                conn.Execute(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                return true;
            });

            _signal.SignalToken(CACHE_MeritCertificateFeature);
            await Task.CompletedTask;
        }

        public async Task<MeritCertificateFeatureModel> GetById(long Id)
        {
            _signal.SignalToken(CACHE_MeritCertificateFeature);
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            string cacheKey = $"{CACHE_MeritCertificateFeature}.getByIdMeritCertificateFeature.{Id}";
            var image = _memoryCache.GetOrCreate(cacheKey, (entry) => {

                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_MeritCertificateFeature));
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);

                return _storage.UseConnection(conn =>
                {
                    string sql = $"[dbo].spGetByIdMeritCertificateFeature @id";
                    return conn.QueryFirstOrDefault<MeritCertificateFeatureModel>(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                });
            });
            return await Task.FromResult(image);
        }


        public async Task<PagedList<MeritCertificateFeatureModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null, long? meritCertificateId = null)
        {
            _signal.SignalToken(CACHE_MeritCertificateFeature);

            string cacheKey = $"{CACHE_MeritCertificateFeature}.GetAsyncMeritCertificateFeature.{count}.{dateStart}";
            var img = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_MeritCertificateFeature));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spListAllMeritCertificateFeature @dateStart,@dateEnd, @startIndex, @count, @searchString, @meritCertificateId";



                    var result = conn.Query<MeritCertificateFeatureModel>(sql, new
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
            var paggedResult = new PagedList<MeritCertificateFeatureModel>(source: img,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }

        public async Task Update(MeritCertificateFeatureModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                    var sql = $"dbo.spUpdateMeritCertificateFeature @id,@feature,@meritCertificateId";

                    conn.Execute(sql,
                        new
                        {

                            id = entity.Id,
                            feature = entity.Feature,
                            meritCertificateId = entity.MeritCertificateId



                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;



                });

                _signal.SignalToken(CACHE_MeritCertificateFeature);
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

      

        //public Task<PagedList<MeritCertificateFeature>> GetAsyncAll(string extension = null, DateTime? dateStart = null, DateTime? dateStop = null, int startIndex = 0, int count = int.MaxValue)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
