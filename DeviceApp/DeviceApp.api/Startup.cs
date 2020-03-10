﻿using System.Net;
using AutoMapper;
using DeviceApp.api.Common;
using DeviceApp.api.lib.Db;
using DeviceApp.api.lib.Repository;
using DeviceApp.api.Model;
using DeviceApp.api.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceApp.api
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
            
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap <DeviceModel, Device>());
            config.AssertConfigurationIsValid();
            
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddTransient<DeviceServiceHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*
         * Handles a common exception format
         * Formatting response as a JSON with unique correlationID can be added - todo
         */
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var errorContext = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorContext.Error is AppException appException)
                    {
                        context.Response.StatusCode = (int) appException.ResponseCode;
                        context.Response.ContentType = "Application/json";
                        await context.Response.WriteAsync(appException.ErrorMessage);
                    }
                    else
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "Application/json";
                        await context.Response.WriteAsync(errorContext.Error.Message);
                    }
                });
            });
            
            //app.UseHttpsRedirection();

            //app.UseAuthentication();
            
            app.UseMvc();
        }
    }
}