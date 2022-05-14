
using Exwhyzee.Lojour.Application.Barner;
using Exwhyzee.Lojour.Application.Communities;
using Exwhyzee.Lojour.Application.DegreeObtained;
using Exwhyzee.Lojour.Application.EducationHistory;
using Exwhyzee.Lojour.Application.EstateProperties;
using Exwhyzee.Lojour.Application.Experience;
using Exwhyzee.Lojour.Application.InterpersonalSkill;
using Exwhyzee.Lojour.Application.JobAnalysis;
using Exwhyzee.Lojour.Application.KindredApp;
using Exwhyzee.Lojour.Application.LanguageSpoken;
using Exwhyzee.Lojour.Application.LGAs;
using Exwhyzee.Lojour.Application.MembershipOfLearneredSociety;
using Exwhyzee.Lojour.Application.MeritCertificate;
using Exwhyzee.Lojour.Application.MeritCertificateFeature;
using Exwhyzee.Lojour.Application.Pages;
using Exwhyzee.Lojour.Application.PropertyFeatures;
using Exwhyzee.Lojour.Application.PropertyImages;
using Exwhyzee.Lojour.Application.PropertyLandMark;
using Exwhyzee.Lojour.Application.RenderedService;
using Exwhyzee.Lojour.Application.RequestProperties;
using Exwhyzee.Lojour.Application.Skill;
using Exwhyzee.Lojour.Application.States;
using Exwhyzee.Lojour.Application.Tour;
using Exwhyzee.Lojour.Application.TrainingAndWorkShop;
using Exwhyzee.Lojour.Application.UserProfile;
using Exwhyzee.Lojour.Application.WorkHistory;
using Exwhyzee.Lojour.Application.WorkImage;
using Exwhyzee.Lojour.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Exwhyzee.Lojour.Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddLojourApplicationServices(this IServiceCollection services)
        {
            services.AddLojourDataServices();
            services.AddTransient<IPropertyAppService, PropertyAppService>();
            services.AddTransient<IRequestPropertyAppService, RequestPropertyAppService>();
            services.AddTransient<ICommunityAppService, CommunityAppService>();
            services.AddTransient<IPropertyImagesAppService, PropertyImagesAppService>();
            services.AddTransient<IKindredAppService, KindredAppService>();
            services.AddTransient<ILGAsAppService, LGAsAppService>();
            services.AddTransient<IStateAppService, StateAppService>();
            services.AddTransient<IPropertyFeaturesAppService, PropertyFeaturesAppService>();
            services.AddTransient<IPropertyLandMarkAppService, PropertyLandMarkAppService>();
            services.AddTransient<IPageAppService, PageAppService>();
            services.AddTransient<IBarnerAppService, BarnerAppService>();
            services.AddTransient<ITourAppService, TourAppService>();

            services.AddTransient<IEducationHistoryAppService, EducationHistoryAppService>();
            services.AddTransient<IExperienceAppService, ExperienceAppService>();
            services.AddTransient<IInterpersonalSkillAppService, InterpersonalSkillAppService>();
            services.AddTransient<ILanguageSpokenAppService, LanguageSpokenAppService>();
            services.AddTransient<IMeritCertificateAppService, MeritCertificateAppService>();
            services.AddTransient<IMeritCertificateFeatureAppService, MeritCertificateFeatureAppService>();
            services.AddTransient<IRenderedServiceAppService, RenderedServiceAppService>();
            services.AddTransient<ISkillAppService, SkillAppService>();
            services.AddTransient<IUserProfileAppService, UserProfileAppService>();
            services.AddTransient<IWorkHistoryAppService, WorkHistoryAppService>();
            services.AddTransient<IWorkImageAppService, WorkImageAppService>();
            services.AddTransient<IDegreeObtainedAppService, DegreeObtainedAppService>();
            services.AddTransient<IMembershipOfLearneredSocietyAppService, MembershipOfLearneredSocietyAppService>();
            services.AddTransient<ITrainingAndWorkShopAppService, TrainingAndWorkShopAppService>();
            services.AddTransient<IJobAnalysisAppService, JobAnalysisAppService>();

            return services;
        }
    }
}
