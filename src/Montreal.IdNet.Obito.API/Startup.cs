using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Montreal.IdNet.Obito.API.Configurations;
using Montreal.IdNet.Obito.Infrastructure.Contexts;
using Montreal.IdNet.Obito.IoC;
using Montreal.IdNet.Obito.IoC.ServiceCollections;
using TSystems.Core.Crosscutting.Domain.Authentication;
using TSystems.Core.Crosscutting.Domain.ErrorHandler;
using TSystems.Core.Crosscutting.Infrastructure.Contexts.SqlServer;

namespace Montreal.IdNet.Obito.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(Configuration);

            services.AddMapper();

            services.AddSwaggerSetup();
            services.AddSqlServerContext<MontrealIdNetObitoContext>(Configuration);

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Local"))
                app.UseDeveloperExceptionPage();
            else
                app.ConfigureExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}