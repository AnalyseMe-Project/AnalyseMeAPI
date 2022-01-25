using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace AnalyseMeAPI {
    public class Startup {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddSingleton<IMongoClient, MongoClient>(s => {
                var url = s.GetRequiredService<IConfiguration>()["DatabaseURL"];
                return new MongoClient(url);
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UsePathBase(new PathString("/api"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
