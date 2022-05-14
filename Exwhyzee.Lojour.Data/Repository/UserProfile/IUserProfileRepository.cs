﻿
using Exwhyzee.Lojour.Core.UserProfile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exwhyzee.Lojour.Data.Repository.UserProfile
{
   public interface IUserProfileRepository
    {
        Task<long> Insert(UserProfileModel map);
        Task<UserProfileModel> GetById(long Id);

        Task<UserProfileModel> GetByUserId(string UserId);

        Task Delete(long Id);

        Task Update(UserProfileModel entity);

        Task<PagedList<UserProfileModel>> GetAsyncAll(DateTime? dateStart = null, DateTime? dateEnd = null, int startIndex = 0, int count = int.MaxValue, string searchString = null);

    }
}
