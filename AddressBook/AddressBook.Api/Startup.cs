using AddressBook.Api.DataContext;
using AddressBook.Api.Repositories;
using AddressBook.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Serilog;

namespace AddressBook.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SqlExpressContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:AddressBookDB"]));

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAddressInfoService, AddressInfoService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<Serilog.ILogger>(x =>
            {
                return new LoggerConfiguration().WriteTo.MSSqlServer(
                    Configuration["ConnectionStrings:AddressBookDB"],
                    Configuration["Serilog:tableName"],
                    Serilog.Events.LogEventLevel.Debug,
                    autoCreateSqlTable: false).MinimumLevel.Information().CreateLogger();
            });

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                    .AddJsonOptions(o => o.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Temp Fix for http responses in .net Core 2.2  
            // https://github.com/aspnet/AspNetCore/issues/6166
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
