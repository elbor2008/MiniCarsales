using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiniCarsales.Api.Data;
using MiniCarsales.Api.Mppers;
using MiniCarsales.Api.Repository;
using MiniCarsales.Api.Validators;

namespace MiniCarsales.Api
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
            services.AddControllers().AddNewtonsoftJson().AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<CarValidator>();
            });

            services.AddCors();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<VehicleDbContext>(builder =>
            {
                builder.UseInMemoryDatabase(Configuration.GetValue<string>("DefaultDB"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
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
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        var errors = context.Features.Get<IExceptionHandlerFeature>();
                        await context.Response.WriteAsync(errors.Error.Message);
                    });
                });
            }

            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
