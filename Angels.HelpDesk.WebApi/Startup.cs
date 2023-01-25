using Angels.HelpDesk.BusinessLogic.ExtensionMethods;
using Angels.HelpDesk.Persistence.ExtentionMethods;
using Microsoft.OpenApi.Models;

namespace Angels.HelpDesk.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistenceLayerExtensions(Configuration);
            services.AddBusinessLogicLayerExtensions();

            services.AddControllers();
            services.AddCors();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Opencity.HelpDesk.WebApi", Version = "v1" }));
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Opencity.HelpDesk.WebApi v1"));
            }

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
