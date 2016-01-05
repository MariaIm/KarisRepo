using KarisMissionChoir.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KarisMissionChoir.DAL
{
    public class KarisMissionChoirContext : IdentityDbContext<ApplicationUser>
    {
        public KarisMissionChoirContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        
        public DbSet<Address> Addresses { get; set; }
        public DbSet<MediaImage> MediaImages { get; set; }
        public static KarisMissionChoirContext Create()
        {
            return new KarisMissionChoirContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
