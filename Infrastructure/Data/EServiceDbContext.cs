using Core.Dots;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.Data
{
   public class EServiceDbContext : IdentityDbContext<ApplicationUser>    //DbContext
    {
        public EServiceDbContext(DbContextOptions<EServiceDbContext> options ) : base (options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    //builder.Entity<IdentityUser>().ToTable("Users", "Identity");
        //    //builder.Entity<IdentityRole>().ToTable("Roles", "Identity");
        //    //builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
        //    //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Identity");
        //    //builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Identity");
        //    //builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Identity");
        //    //builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Identity");

        //    //builder.Entity<Category>().Property(x => x.Id).HasDefaultValueSql("(newid())");
        //    //builder.Entity<LogCategory>().Property(x => x.Id).HasDefaultValueSql("(newid())");
        //    //builder.Entity<SubCategory>().Property(x => x.Id).HasDefaultValueSql("(newid())");
        //    //builder.Entity<LogSubCategory>().Property(x => x.Id).HasDefaultValueSql("(newid())");
        //    //builder.Entity<Book>().Property(x => x.Id).HasDefaultValueSql("(newid())");
        //    //builder.Entity<LogBook>().Property(x => x.Id).HasDefaultValueSql("(newid())");
        //    //builder.Entity<VwUser>().HasNoKey().ToView("VwUsers");
        //    ////builder.Entity<VwUser>(entity =>
        //    //{
        //    //    entity.HasNoKey();
        //    //    entity.ToView("VwUsers");
        //    //});
        //}
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceDetails> ServiceDetails { get; set; }
        public DbSet<ClientRequest> ClientRequest{ get; set; }
       
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<ClientRequestView>(entity =>
            //{
            //    entity.HasNoKey();
            //    entity.ToView("ClientRequestView");
            //});
           // modelBuilder.Entity<ClientRequestView>().HasNoKey().ToView("ClientRequestView");

        }
    }
}
