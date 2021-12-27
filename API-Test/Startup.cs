using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer.AdoRepositories;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API_Test
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Test", Version = "v1" });
            });
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Test v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
