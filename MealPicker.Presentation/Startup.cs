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
using System.Reflection;
using System.Threading.Tasks;
using AutoWrapper;
using MealPicker.Application.Commands.AddNewMealCommand;
using MealPicker.Application.Interfaces;
using MealPicker.Application.Utils;
using MealPicker.Presistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MealPicker.Presentation
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
            services.AddCors();
            services.AddControllers();
            services.AddMediatR(typeof(AddNewMealCommand).GetTypeInfo().Assembly);
            services.AddDbContext<MealPickerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MealPickerContext")));
            services.AddScoped<IContext>(provider => provider.GetService<MealPickerContext>());
            var connectionString = new ConnectionString(Configuration.GetConnectionString("MealPickerContext"));


            services.AddSingleton(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MealPickerContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseApiResponseAndExceptionWrapper(options:new AutoWrapperOptions(){UseCustomSchema = true});
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
