using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RT09QT_HFT_2022231.Logic;
using RT09QT_HFT_2022231.Logic.Interfaces;
using RT09QT_HFT_2022231.Repository;
using RT09QT_HFT_2022231.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT09QT_HFT_2022231.Endpoint
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
            services.AddTransient<CountryDbContext>();
            services.AddTransient<ICountryRepository,  CountryRepository>();
            services.AddTransient<ICountyRepository, CountyRepository>();
            services.AddTransient<ITownRepository, TownRepository>();
            services.AddTransient<IinhabitantRepository, InhabitantRepository>();

            services.AddTransient<ICountryLogic, CountryLogic>();
            services.AddTransient<ICountyLogic, CountyLogic>();
            services.AddTransient<ITownLogic, TownLogic>();
            services.AddTransient<IInhabitantLogic, InhabitantLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RT09QT_HFT_2022231.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RT09QT_HFT_2022231.Endpoint v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
