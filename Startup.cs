using Amazon.S3;
using ConnectingPlusAPI.Data;
using ConnectingPlusAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectingPlusAPI.Hubs;


namespace ConnectingPlusAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ConnectingPlusAPI", Version = "v1" });
            });
            services.AddSignalR();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMimetype, Mimetypecs>();
            services.AddScoped<IShop, Shop>();
            services.AddScoped<ISearchingRepository, SearchingRepository>();
            services.AddScoped<IShopItemRepository, ShopItemsRepository>();
            services.AddScoped<IProve, Prove>();
            services.AddScoped<ISearcheRepository, SearcheRepository>();
            services.AddScoped<IPurchase, Purchase>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IPrRepository, PrRepository>();
            services.AddScoped<IRoomChatRepository, RoomChatRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConnectingPlusAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/hubs/chat");
            });
        }
    }
}
