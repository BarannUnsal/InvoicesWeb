using InvoicesAPI.Business.Filter;
using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.UserRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.InvoiceRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.UserRepo;
using InvoicesAPI.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            services.AddScoped<ICreditCardReadRepository, CreditCardReadRepository>();
            services.AddScoped<ICreditCardWriteRepository, CreditCartWriteRepository>();
            services.AddScoped<IHouseReadRepository, HouseReadRepository>();
            services.AddScoped<IHouseWriteRepository, HouseWriteRepository>();
            services.AddScoped<IInvoicesReadRepository, InvoiceReadRepository>();
            services.AddScoped<IInvociesWriteRepository, InvoiceWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

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
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
