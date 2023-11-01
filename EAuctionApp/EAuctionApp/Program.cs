using EAuctionApp.Model;
using EAuctionApp.Repository;
using EAuctionApp.Services;
using EAuctionApp.ConstantClasses;
using Microsoft.EntityFrameworkCore;
using EAuctionApp.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EAuctionApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AuctionContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Adding Authentication  
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

              // Adding Jwt Bearer  
              .AddJwtBearer(options =>
              {
                  options.SaveToken = true;
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidAudience = builder.Configuration["JWT:ValidAudience"],
                      ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                  };
              });

            //builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
            builder.Services.AddTransient<IBidDetailRepository, BidDetailRepository>();

            
            CategoryDetails categoryDetails = new CategoryDetails();
            categoryDetails.AddCategory();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //builder.Services.AddDbContext<AuctionContext>();
            

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
       => Host.CreateDefaultBuilder(args)
           .ConfigureWebHostDefaults(
               webBuilder => webBuilder.UseStartup<Startup>());
    }
}