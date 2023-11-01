using EAuctionApp.Authentication;
using EAuctionApp.Model;
using EAuctionApp.Repository;
using EAuctionApp.Services;
using Microsoft.EntityFrameworkCore;

namespace EAuctionApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            
            services.AddHttpContextAccessor();
            services.AddDbContext<AuctionContext>(x => x.UseSqlServer(app.Configuration.GetConnectionString("ConStr")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
