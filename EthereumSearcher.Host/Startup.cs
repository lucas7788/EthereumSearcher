using AutoMapper;
using EthereumSearcher.Common.MappingProfiles;
using EthereumSearcher.Common.Models;
using EthereumSearcher.Data;
using EthereumSearcher.Data.Interfaces;
using EthereumSearcher.Services;
using EthereumSearcher.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumSearcher.Host
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
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(EthereumTransactionMappingProfile));
            //var config = new MapperConfiguration(cfg => {
            //    cfg.AddProfile<EthereumTransactionMappingProfile>();
            //});

            services.AddScoped<ISearchRepository<EthereumTransaction>, EthereumRepository>();
            services.AddScoped<ISearchService, SearchService>();

            
            //_ = new MapperConfiguration(cfg =>
            //            cfg.AddMaps(new[] {
            //            "EthereumSearcher.Common"}),);

            services.AddHttpClient("ethereumApi", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetSection("InfuraSettings")["BaseUri"]);
                c.DefaultRequestHeaders.Clear();
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EthereumSearcher V1");
                c.RoutePrefix = string.Empty;
            });


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
