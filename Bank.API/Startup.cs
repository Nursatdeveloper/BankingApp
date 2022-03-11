using Bank.Application.Handlers.UserCommandHandlers;
using Bank.Application.Services;
using Bank.Application.Services.JwtService;
using Bank.Application.Validations;
using Bank.Core.Repositories;
using Bank.Core.Repositories.Base;
using Bank.Infrastructure.Data;
using Bank.Infrastructure.Repositories;
using Bank.Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
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
using System.Reflection;
using System.Threading.Tasks;

namespace Bank.API
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
            services.AddCors(c => c.AddPolicy("AllowOrigin", options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank.API", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")), ServiceLifetime.Singleton);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IBankOperationRepository, BankOperationRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();

            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAccountValidator, AccountValidator>();
            services.AddScoped<IUserValidator, UserValidator>();

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateUserHandler).GetTypeInfo().Assembly);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                            ValidateIssuer = true,
                            ValidIssuer = UserAuthenticationOptions.ISSUER,
                            ValidateAudience = true,
                            ValidAudience = UserAuthenticationOptions.AUDIENCE,
                            ValidateLifetime = true,
                            IssuerSigningKey = UserAuthenticationOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                       };
                   });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank.API v1"));
            }
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
