using InvoicesAPI.Entity;
using InvoicesAPI.Entity.Common;
using InvoicesAPI.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.DataAccess.Context
{
    public class InvoicesApiDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public InvoicesApiDbContext(DbContextOptions<InvoicesApiDbContext> options) : base(options)
        {

        }
        DbSet<Homeowner> Homeowners{ get; set; }
        DbSet<Invoice> Invoices { get; set;}
        DbSet<House> Houses { get; set; }
        DbSet<CreditCard> CreditCards { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<InvoiceFile> InvoiceFiles { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach(var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedTime = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
