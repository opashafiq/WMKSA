using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<BranchMaster> BranchMaster { get; set; }
        public DbSet<CustomerMaster> CustomerMaster { get; set; }
        public DbSet<SubCustomerMaster> SubCustomerMaster { get; set; }
        public DbSet<VendorMaster> VendorMaster { get; set; }
        public DbSet<TransporterMaster> TransporterMaster { get; set; }
        public DbSet<TruckMaster> TruckMaster { get; set; }
        public DbSet<DriverMaster> DriverMaster { get; set; }
        public DbSet<PackageMaster> PackageMaster { get; set; }
        public DbSet<UnitMaster> UnitMaster { get; set; }
        public DbSet<RecItemMaster> RecItemMaster { get; set; }
        public DbSet<ItemService> ItemService { get; set; }
        public DbSet<ItemsRateMaster> ItemsRateMaster { get; set; }
        public DbSet<ItemsRateMasterDetail> ItemsRateMasterDetail { get; set; }
        public DbSet<JobOrder> JobOrder { get; set; }
        public DbSet<ReceiveItemsNew> ReceiveItemsNew { get; set; }
        public DbSet<ReceiveItemsNewDetail> ReceiveItemsNewDetails { get; set; }
        public DbSet<ReceiveItemsNewRelease> ReceiveItemsNewRelease { get; set; }
        public DbSet<ReceiveItemsNewReleaseDetail> ReceiveItemsNewReleaseDetails { get; set; }

        //SP
        public DbSet<ReceiveItemsNewFromUSPGatein> ReceiveItemsNewFromUSPGatein { get; set; }
        public DbSet<ReceiveItemsNewReleaseGateOut> ReceiveItemsNewReleaseGateOut { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ReceiveItemsNewFromUSPGatein>().HasNoKey();
            builder.Entity<ReceiveItemsNewReleaseGateOut>().HasNoKey();
 

        }


    }
}
