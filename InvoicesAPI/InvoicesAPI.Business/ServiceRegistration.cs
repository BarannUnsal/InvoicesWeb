using InvoicesAPI.Business.Abstraction;
using InvoicesAPI.Business.Abstraction.JwtToken;
using InvoicesAPI.Business.Services.JwtToken;
using InvoicesAPI.Business.Services.Storage;
using InvoicesAPI.Business.Services.Storage.Azure;
using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoiceFileRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.UserRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.InvoiceFileRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.InvoiceRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.UserRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity.Identity;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoicesAPI.Business
{
    public static class ServiceRegistration
    {
        public static IConfiguration Configuration { get; }

        public static void BusinessServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration).Assembly);
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
        public static void DataBaseServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<InvoicesApiDbContext>();
            services.AddScoped<ICreditCardReadRepository, CreditCardReadRepository>();
            services.AddScoped<ICreditCardWriteRepository, CreditCartWriteRepository>();
            services.AddScoped<IHouseReadRepository, HouseReadRepository>();
            services.AddScoped<IHouseWriteRepository, HouseWriteRepository>();
            services.AddScoped<IInvoicesReadRepository, InvoiceReadRepository>();
            services.AddScoped<IInvociesWriteRepository, InvoiceWriteRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IHomeownerReadRepository, HomeownerReadRepository>();
            services.AddScoped<IHomeownerWriteRepository, HomeownerWriteRepository>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IStorage, AzuraStorage>();
        }
    }
}
