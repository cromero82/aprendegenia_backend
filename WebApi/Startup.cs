using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using Domain;
using Infraestructura;
using Infraestructura.Dto;
using Domain.Services;

namespace WebApi
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
            services.AddDbContext<Domain.ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("AppDbContext"))
            );
            services.AddScoped<IUnitOfWorks, UnitOfWork>();
            services.AddScoped<IService<PersonaDto>, PersonaService>();
            services.AddControllers();

            // The following will be picked up by Application Insights.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			});
            app.UseCors(builder => 
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()//.WithOrigins("http://localhost:4200")
            );
            // app.UsePathBase(Configuration.GetValue<string>("Subdirectory"));
        }
    }
}
