using BooksCatalog.API.Consumers;
using BooksCatalog.API.Services;
using BooksCatalog.API.Services.Contracts;
using BooksCatalog.Domain.Interfaces;
using BooksCatalog.Infra.Data;
using BooksCatalog.Infra.Messaging;
using BooksCatalog.Infra.Messaging.Contracts;
using BooksCatalog.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BooksCatalog.API
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "BooksCatalog.API", Version = "v1"});
            });

            services.AddLogging(builder => builder.AddSeq(Configuration.GetSection("Seq")));

            services.AddDbContext<BooksCatalogContext>();

            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped<IServiceBus, ServiceBus>();
            
            services.AddScoped<IBookRepository, BooksRepository>();

            services.AddHostedService<BookRentedConsumer>();
            services.AddHostedService<BookReturnedConsumer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BooksCatalog.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}