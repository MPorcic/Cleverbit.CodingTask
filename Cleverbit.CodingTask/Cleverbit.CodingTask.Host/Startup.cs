using Cleverbit.CodingTask.Data;
using Cleverbit.CodingTask.Host.Auth;
using Cleverbit.CodingTask.Host.Interfaces;
using Cleverbit.CodingTask.Host.Repositories;
using Cleverbit.CodingTask.Host.Services;
using Cleverbit.CodingTask.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.IO;

namespace Cleverbit.CodingTask.Host
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder => {
                        builder.WithOrigins("http://localhost:4200")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                    });
            });
            services
                .AddDbContext<CodingTaskContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //repositories
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<IMatchEntryRepository, MatchEntryRepository>();
            services.AddTransient<IMatchResultRepository, MatchResultRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            //app services
            services.AddTransient<IMatchAppService, MatchAppService>();
            services.AddTransient<IMatchEntryAppService, MatchEntryAppService>();
            services.AddTransient<IMatchResultAppService, MatchResultAppService>(); 
            services.AddTransient<IAuthAppService, AuthAppService>();


            services.AddSingleton<IHashService>(new HashService(configuration.GetSection("HashSalt").Get<string>()));

            services.AddControllers();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "Views")),
                RequestPath = "/Views"
            });

            app.UseCors("AllowOrigin");

            app.UseRouting();

            //TODO: REMOVE TEST MIDDLEWARE ON CLEANUP
            app.Use(async (context, next) =>
            {
                var cultureQuery = context.Request.Query["culture"];
                if (!string.IsNullOrWhiteSpace(cultureQuery))
                {
                    var culture = new CultureInfo(cultureQuery);

                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;
                }

                // Call the next delegate/middleware in the pipeline
                await next();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
