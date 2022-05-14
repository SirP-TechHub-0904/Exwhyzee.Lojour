using Dapper;
using Exwhyzee.Caching;
using Exwhyzee.Data;
using Exwhyzee.Lojour.Core.UserProfile;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.UserProfile
{
    public class UserProfileRepository : IUserProfileRepository
    {
        #region constants
        private const string CACHE_UserProfile = "Exwhyzee.Lojour.Data.UserProfile";
        private const int CACHE_EXPIRATION_MINUTE = 30;
        #endregion

        #region Fields
        private readonly IStorage _storage;
        private readonly IMemoryCache _memoryCache;
        private readonly ISignal _signal;
        private readonly IClock _clock;
        #endregion

        #region Ctor
        public UserProfileRepository(IStorage storage, IMemoryCache memoryCache, ISignal signal, IClock clock)
        {
            _storage = storage;
            _memoryCache = memoryCache;
            _signal = signal;
            _clock = clock;
        }

        public async Task<long> Insert(UserProfileModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {

                    var sql = $"dbo.spInsertUserProfile @title,@surName,@firstName,@lastName,@contactAddress,@country,@description,@dateOfBirth,@dateRegistered,@userId,@facebookLink,@twitterLink,@linkedinLink,@photoUrl,@complementryCardKeywords,@lojourId,@gender,@maritalStatus";


                    entity.Id = conn.ExecuteScalar<int>(sql,
                        new
                        {

                            title = entity.Title,
                            surName = entity.SurName,
                            firstName = entity.FirstName,
                            lastName = entity.LastName,
                            contactAddress = entity.ContactAddress,
                            country = entity.Country,
                            description = entity.Description,
                            dateOfBirth = entity.DateOfBirth,
                            dateRegistered = entity.DateRegistered,
                            userId = entity.UserId,
                            facebookLink = entity.FacebookLink,
                            twitterLink = entity.TwitterLink,
                            linkedinLink = entity.LinkedinLink,
                            photoUrl = entity.PhotoUrl,
                            complementryCardKeywords = entity.ComplementryCardKeywords,
                            lojourId = entity.LojourId,
                            gender = entity.Gender,
                            marialStatus = entity.MaritalStatus


                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;
                });

                _signal.SignalToken(CACHE_UserProfile);

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
                string sql = "spDeleteUserProfile @Id";
                conn.Execute(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                return true;
            });

            _signal.SignalToken(CACHE_UserProfile);
            await Task.CompletedTask;
        }

        public async Task<UserProfileModel> GetById(long Id)
        {
            _signal.SignalToken(CACHE_UserProfile);
            if (Id < 1)
                throw new ArgumentOutOfRangeException(nameof(Id));

            string cacheKey = $"{CACHE_UserProfile}.getByIdUserProfile.{Id}";
            var image = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {

                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_UserProfile));
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);

                return _storage.UseConnection(conn =>
                {
                    string sql = $"[dbo].spGetByIdUserProfile @id";
                    return conn.QueryFirstOrDefault<UserProfileModel>(sql, new { Id }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                });
            });
            return await Task.FromResult(image);
        }


        public async Task<PagedList<UserProfileModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null)
        {
            _signal.SignalToken(CACHE_UserProfile);

            string cacheKey = $"{CACHE_UserProfile}.GetAsyncUserProfile.{count}.{dateStart}";
            var img = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);
                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_UserProfile));
                return _storage.UseConnection(conn =>
                {
                    string sql = $"dbo.spListAllUserProfile @dateStart,@dateEnd, @startIndex, @count, @searchString";



                    var result = conn.Query<UserProfileModel>(sql, new
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
            var paggedResult = new PagedList<UserProfileModel>(source: img,
                                pageIndex: startIndex,
                                pageSize: count,
                                filteredCount: filterCount,
                                totalCount: filterCount);

            return await Task.FromResult(paggedResult);
        }

        public async Task Update(UserProfileModel entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity = _storage.UseConnection(conn =>
                {
                    var sql = $"dbo.spUpdateUserProfile @id,@title,@surName,@firstName,@lastName,@contactAddress,@country,@description,@dateOfBirth,@dateRegistered,@userId,@facebookLink,@twitterLink,@linkedinLink,@photoUrl,@complementryCardKeywords,@lojourId,@gender,@maritalStatus";

                    conn.Execute(sql,
                        new
                        {

                            id = entity.Id,
                            title = entity.Title,
                            surName = entity.SurName,
                            firstName = entity.FirstName,
                            lastName = entity.LastName,
                            contactAddress = entity.ContactAddress,
                            country = entity.Country,
                            description = entity.Description,
                            dateOfBirth = entity.DateOfBirth,
                            dateRegistered = entity.DateRegistered,
                            userId = entity.UserId,
                            facebookLink = entity.FacebookLink,
                            twitterLink = entity.TwitterLink,
                            linkedinLink = entity.LinkedinLink,
                            photoUrl = entity.PhotoUrl,
                            complementryCardKeywords = entity.ComplementryCardKeywords,
                            lojourId = entity.LojourId,
                            gender = entity.Gender,
                            maritalStatus = entity.MaritalStatus


                        },
                        commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);

                    return entity;



                });

                _signal.SignalToken(CACHE_UserProfile);
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

        public async Task<UserProfileModel> GetByUserId(string UserId)
        {
            _signal.SignalToken(CACHE_UserProfile);
            if (String.IsNullOrEmpty(UserId))
                throw new ArgumentOutOfRangeException(nameof(UserId));

            string cacheKey = $"{CACHE_UserProfile}.getByIdUserProfile.{UserId}";
            var image = _memoryCache.GetOrCreate(cacheKey, (entry) =>
            {

                entry.ExpirationTokens.Add(_signal.GetToken(CACHE_UserProfile));
                entry.AbsoluteExpiration = _clock.UtcNow.AddMinutes(CACHE_EXPIRATION_MINUTE);

                return _storage.UseConnection(conn =>
                {
                    string sql = $"[dbo].spGetByUserIdUserProfile @userId";
                    return conn.QueryFirstOrDefault<UserProfileModel>(sql, new { UserId }, commandTimeout: DataConstants.COMMAND_TIMEOUT_SECONDS);
                });
            });
            return await Task.FromResult(image);
        }



        //public Task<PagedList<UserProfile>> GetAsyncAll(string extension = null, DateTime? dateStart = null, DateTime? dateStop = null, int startIndex = 0, int count = int.MaxValue)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        #endregion
    }
}
