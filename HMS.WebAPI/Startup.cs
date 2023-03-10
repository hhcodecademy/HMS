using FluentValidation.AspNetCore;
using HMS.BLL.Mapping;
using HMS.BLL.Services;
using HMS.BLL.Services.Interface;
using HMS.BLL.Validations;
using HMS.DAL.Data;
using HMS.DAL.Repositories;
using HMS.DAL.Repositories.Interfaces;
using HMS.WebAPI.Helper.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.WebAPI
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
            services.AddDbContext<AppDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
                opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });
            services.AddAutoMapper(typeof(CustomMapping));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddRepositories();
            services.AddServices();

            string key = Configuration.GetValue<string>("SecretInfo:SecretKey");

                 services.AddAuthentication(conf =>
                 {
                     conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 }).AddJwtBearer(x =>
                 {

                     x.RequireHttpsMetadata = false;
                     x.SaveToken = true;
                     x.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidateLifetime = true,
                         LifetimeValidator = TokenLifetimeValidator.Validate,

                     };

                 });
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DoctorValidator>()); ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HMS.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HMS.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public static class TokenLifetimeValidator
        {
            public static bool Validate(
                DateTime? notBefore,
                DateTime? expires,
                SecurityToken tokenToValidate,
                TokenValidationParameters @param
            )
            {
                return (expires != null && expires > DateTime.UtcNow);
            }
        }
    }
}
