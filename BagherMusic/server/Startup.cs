// Internal
using BagherMusic.Models;
using BagherMusic.Services;

// Microsoft
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BagherMusic
{
	public class Startup
	{
		readonly string SpecificSearchClientOrigins = "SearchOrigins";
		readonly string SpecificEntityClientOrigins = "EntitiesOrigins";
		readonly string SpecificImportClientOrigins = "ImportOrigins";
		readonly string AngularServer = "http://localhost:4200";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(
				options =>
				{
					options.AddPolicy(
						SpecificSearchClientOrigins,
						builder =>
						{
							builder.WithOrigins(AngularServer)
								.WithMethods("GET")
								.AllowAnyHeader();
						}
					);
					options.AddPolicy(
						SpecificEntityClientOrigins,
						builder =>
						{
							builder.WithOrigins(AngularServer)
								.WithMethods("GET")
								.AllowAnyHeader();
						}
					);
					options.AddPolicy(
						SpecificImportClientOrigins,
						builder =>
						{
							builder.WithOrigins(AngularServer)
								.WithMethods("POST")
								.AllowAnyHeader();
						}
					);
				}
			);
			services.AddControllers();
			services.AddSingleton<IElasticClientService, ElasticClientService>();
			services.AddSingleton<IElasticService<int, Music>, ElasticMusicService>();
			services.AddSingleton<IElasticService<int, Artist>, ElasticArtistService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseRouting();

			app.UseCors(SpecificSearchClientOrigins);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
