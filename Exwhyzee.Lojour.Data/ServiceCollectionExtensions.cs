using Exwhyzee.Extensions.DependencyInjection;
using Exwhyzee.Lojour.Data.Repository.BarnerImages;
using Exwhyzee.Lojour.Data.Repository.Community;
using Exwhyzee.Lojour.Data.Repository.DegreeObtained;
using Exwhyzee.Lojour.Data.Repository.EducationHistory;
using Exwhyzee.Lojour.Data.Repository.EstateProperties;
using Exwhyzee.Lojour.Data.Repository.Experience;
using Exwhyzee.Lojour.Data.Repository.InterpersonalSkill;
using Exwhyzee.Lojour.Data.Repository.JobAnalysis;
using Exwhyzee.Lojour.Data.Repository.Kindred;
using Exwhyzee.Lojour.Data.Repository.LanguageSpoken;
using Exwhyzee.Lojour.Data.Repository.LGA;
using Exwhyzee.Lojour.Data.Repository.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Data.Repository.MeritCertificate;
using Exwhyzee.Lojour.Data.Repository.MeritCertificateFeature;
using Exwhyzee.Lojour.Data.Repository.Pages;
using Exwhyzee.Lojour.Data.Repository.PropertyFeatures;
using Exwhyzee.Lojour.Data.Repository.PropertyImages;
using Exwhyzee.Lojour.Data.Repository.PropertyLandMark;
using Exwhyzee.Lojour.Data.Repository.RenderedService;
using Exwhyzee.Lojour.Data.Repository.RequestProperties;
using Exwhyzee.Lojour.Data.Repository.Skill;
using Exwhyzee.Lojour.Data.Repository.State;
using Exwhyzee.Lojour.Data.Repository.Tour;
using Exwhyzee.Lojour.Data.Repository.TrainingAndWorkShop;
using Exwhyzee.Lojour.Data.Repository.UserProfile;
using Exwhyzee.Lojour.Data.Repository.WorkHistory;
using Exwhyzee.Lojour.Data.Repository.WorkImage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exwhyzee.Lojour.Data
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Lojour Data services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddLojourDataServices(this IServiceCollection services)
        {
            services.AddExwhyzeeData();
            services.AddExwhyzeeCoreServices();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IRequestPropertyRepository, RequestPropertyRepository>();
            services.AddTransient<IPropertyImagesRepository, PropertyImagesRepository>();
            services.AddTransient<ICommunityRepository, CommunityRepository>();
            services.AddTransient<IKindredRepository, KindredRepository>();
            services.AddTransient<ILgaRepository, LgaRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IPropertyFeaturesRepository, PropertyFeaturesRepository>();
            services.AddTransient<IPropertyLandMarksRepository, PropertyLandMarksRepository>();
            services.AddTransient<IBarnerRepository, BarnerRepository>();
            services.AddTransient<IPageRepository, PageRepository>();
            services.AddTransient<ITourRepository, TourRepository>();

            services.AddTransient<IEducationHistoryRepository, EducationHistoryRepository>();
            services.AddTransient<IExperienceRepository, ExperienceRepository>();
            services.AddTransient<IInterpersonalSkillRepository, InterpersonalSkillRepository>();
            services.AddTransient<ILanguageSpokenRepository, LanguageSpokenRepository>();
            services.AddTransient<IMeritCertificateRepository, MeritCertificateRepository>();
            services.AddTransient<IMeritCertificateFeatureRepository, MeritCertificateFeatureRepository>();
            services.AddTransient<IRenderedServiceRepository, RenderedServiceRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IWorkHistoryRepository, WorkHistoryRepository>();
            services.AddTransient<IWorkImageRepository, WorkImageRepository>();
            services.AddTransient<IDegreeObtainedRepository, DegreeObtainedRepository>();
            services.AddTransient<IMembershipOfLearneredSocietyRepository, MembershipOfLearneredSocietyRepository>();
            services.AddTransient<ITrainingAndWorkShopRepository, TrainingAndWorkShopRepository>();
            services.AddTransient<IJobAnalysisRepository, JobAnalysisRepository>();

            
            return services;

        }
    }
}
