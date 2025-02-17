using Bussines.Abstarct;
using Bussines.Concrete;
using Bussines.Security.Abstract;
using Bussines.Security.Concrete;
using Core.Helpers.EmailHelper.Abstract;
using Core.Helpers.EmailHelper.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;


namespace Bussines.DependencyResolver
{
   public static class ServiceRegistration
    {

        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ITokenService, TokenManager>();
            services.AddScoped<IEmailHelper, EmailHelper>();
            services.AddScoped<IMainService, MainManager>();
            services.AddScoped<IMainDAL, EFMainDAL>();
            services.AddScoped<IAboutMeDAL, EFAboutDAL>();
            services.AddScoped<IAboutMeService, AboutMeManager>();
            services.AddScoped<IEducationService, EducationManager>();
            services.AddScoped<IEducationDAL, EFEducationDAL>();
            services.AddScoped<IProjectDAL, EFProjectDAL>();
            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<ISkillDAL, EFSkillDAL>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<IContactMeDAL, EFContactMeDAL>();
            services.AddScoped<IContactMeService, ContactMeManager>();
        }
    }
}
