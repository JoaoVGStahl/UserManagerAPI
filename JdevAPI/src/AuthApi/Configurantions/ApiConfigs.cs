using AuthApi.Data.Context;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace AuthApi.Configurantions
{
    public static class ApiConfigs
    {
        public static void ApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("Default", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers(opt =>
            {
                //opt.Filters.Add(new AuthorizeFilter());

            }).AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "JG Sistemas - User Api", Version = "v1" });
            });

            var connectionString = configuration.GetConnectionString("GlobalContext");

            services.AddDbContext<GlobalContext>(opt =>
            {
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
    }
}
