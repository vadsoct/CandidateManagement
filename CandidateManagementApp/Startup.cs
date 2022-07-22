using CandidateManagement.Domain.Interfaces;
using CandidateManagement.Infra.Data;
using CandidateManagement.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateManagementApp
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
            services.AddMediatR(AppDomain.CurrentDomain.Load("CandidateManagement.Application"));
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("CandidateManagement.Application"));

            services.AddScoped<ICandidateManagementRepository, CandidateManagementRepository>();
            services.AddScoped<ICandidateManagementExperienceRepository, CandidateManagementExperienceRepository>();

            services.AddDbContext<CandidateManagementDBContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("CandidateManagement"))
            );

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CandidateManagement}/{action=Index}/{id?}");
            });
        }
    }
}
