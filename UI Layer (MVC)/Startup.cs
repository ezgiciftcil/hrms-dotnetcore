using BusinessLayer.Auth;
using BusinessLayer.Auth.Interfaces;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.AdoRepositories;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI_Layer__MVC_
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IUserDal, AdoUserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployerDal, AdoEmployerRepository>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<ICityDal, AdoCityRepository>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IJobAdvertisementDal, AdoJobAdvertisementRepository>();
            services.AddScoped<IJobAdvertisementService, JobAdvertisementService>();
            services.AddScoped<IJobSeekerDal, AdoJobSeekerRepository>();
            services.AddScoped<IJobSeekerService, JobSeekerService>();
            services.AddScoped<IResumeDal, AdoResumeRepository>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<IEducationDal, AdoEducationRepository>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<ISkillDal, AdoSkillRepository>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IExperienceDal, AdoExperienceRepository>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IAuthService, AuthService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });

        }
    }
}
