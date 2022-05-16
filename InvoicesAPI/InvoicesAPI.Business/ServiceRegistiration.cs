using InvoicesAPI.Business.Abstract;
using InvoicesAPI.Business.Concrete;
using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using InvoicesAPI.DataAccess.Abstract.Repository.UserRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.InvoiceRepo;
using InvoicesAPI.DataAccess.Concrete.Repository.UserRepo;
using Microsoft.Extensions.DependencyInjection;

namespace InvoicesAPI.Business
{
    public static class ServiceRegistiration
    {
        public static void AddBusinessRegistration(this ServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }
        public static void AddDALRegistration(this IServiceCollection services)
        {

            services.AddScoped<ICreditCardReadRepository, CreditCardReadRepository>();
            services.AddScoped<ICreditCardWriteRepository, CreditCartWriteRepository>();
            services.AddScoped<IHouseReadRepository, HouseReadRepository>();
            services.AddScoped<IHouseWriteRepository, HouseWriteRepository>();
            services.AddScoped<IInvoicesReadRepository, InvoiceReadRepository>();
            services.AddScoped<IInvociesWriteRepository, InvoiceWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        }
    }
}
