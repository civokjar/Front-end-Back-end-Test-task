using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TestTask.Core.Dapper;
using TestTask.Core.Repositories;
using TestTask.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.API
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                  builder => builder.WithOrigins("https://localhost:44330", "https://localhost:44359").AllowAnyHeader()
            .AllowAnyMethod());

            });
           
            services.AddControllers()

            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            }); 
        

            services.AddSingleton<ICustomerDbConfiguration>(t=> new CustomerDbConfiguration(Configuration.GetConnectionString("CustomerDb")));

            services.AddMediatR(typeof(CustomerRepository).Assembly);
            services.AddScoped<ICustomerRepository, CustomerRepository>();
      
            
            DapperConfig.RegisterConventions();

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestTask.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestTask.API v1"));
            }

            app.UseHttpsRedirection();
     
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
