using InvoicesAPI.Business;
using InvoicesAPI.Business.Abstraction;
using InvoicesAPI.Business.Filter;
using InvoicesAPI.Business.Services.Storage;
using InvoicesAPI.Business.Services.Storage.Azure;
using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.UserRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.InvoiceRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.UserRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace InvoicesAPI.Api
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
            services.AddCors(options => options.AddDefaultPolicy(policy =>
                 policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
            ));
            services.AddControllers(options => options.Filters.Add<ValidationFilter>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InvoicesAPI.Api", Version = "v1" });
            });
            services.AddDbContext<InvoicesApiDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.DataBaseServices();
            services.BusinessServices();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new()
                {
                    ValidateAudience = true, // Olu�turulacak token de�erini kimlerin/server kullanaca��n� belirleme
                    ValidateIssuer = true, //Token de�erini kimin da��tt���
                    ValidateLifetime = true, // ya�am s�resi
                    ValidateIssuerSigningKey = true, // security key

                    ValidAudience = Configuration["Token:Audience"],
                    ValidIssuer = Configuration["Token:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]))
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InvoicesAPI.Api v1"));
            }
            app.UseStaticFiles();
            app.UseCors();

            app.UseHttpsRedirection();

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
