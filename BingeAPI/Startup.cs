using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingeAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BingeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen( options => {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Binge API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "frontend.com")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddDbContext<AppDatabase>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("sqlDatabase"));
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Binge API");
            });

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
