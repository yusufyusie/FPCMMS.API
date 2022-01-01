using FPCMMS.API.ActionFilters;
using FPCMMS.API.Extensions;
using FPCMMS.Application.Contracts;
using FPCMMS.Application.Contracts.Identity;
using FPCMMS.Application.Services;
using FPCMMS.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.HttpOverrides;

namespace FPCMMS.API
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
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.ConfigureIdentitySqlContext(Configuration);
            services.AddApplicationServices();
            services.ConfigurePersistenceSqlDBContext(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ValidationFilterAttribute>();
            services.AddApiVersioningConfiguration();

            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            services.AddControllers();
            services.AddSwaggerService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            //  app.ConfigureExceptionHandler(logger);
            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });



            app.UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
              });

            app.UseResponseCaching();
            app.UseErrorHandlingMiddleware();

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
