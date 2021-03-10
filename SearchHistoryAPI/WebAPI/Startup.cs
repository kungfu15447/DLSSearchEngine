using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SearchHistoryAPI.Context;
using SearchHistoryAPI.Services;

namespace SearchHistoryAPI.WebAPI
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
            var useInMemory = Configuration.GetValue<bool>("ConfigValues:UseInMemory");
            if (useInMemory)
            {
                var sqlite = new SqliteConnection("Data Source = History.db");
                sqlite.Open();
                services.AddDbContext<HistoryContext>(options =>
                    SqliteDbContextOptionsBuilderExtensions.UseSqlite(options, sqlite));
            }
            else
            {
                services.AddDbContext<HistoryContext>(options =>
                    SqlServerDbContextOptionsExtensions.UseSqlServer(options,
                        Configuration["ConnectionStrings:HistoryDB"]));
            }

            services.AddScoped<IHistoryService, HistoryService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SearchHistoryAPI", Version = "v1"});
            });

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<HistoryContext>();
                    context.Database.EnsureCreated();
                }

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SearchHistoryAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}