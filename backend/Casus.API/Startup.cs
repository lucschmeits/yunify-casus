using Casus.Application.Interfaces;
using Casus.Application.Services;
using Casus.Core.Interfaces;
using Casus.Core.Services;
using Casus.DAL.Mongo;
using Casus.DAL.Mongo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Casus.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<MongoConnection>(Configuration.GetSection("AppSettings"));
            services.AddScoped<ReservationManager>();
            services.AddScoped<IOfficeAppService, OfficeAppService>();
            services.AddScoped<IOfficeRepository, MongoOfficeRepository>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(
                     options => options.WithOrigins("*").AllowAnyMethod()
                 );
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
