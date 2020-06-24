using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastProblem20200624
{
    public class CastProblemDbContext : DbContext
    {
        public CastProblemDbContext(DbContextOptions<CastProblemDbContext> options) : base(options)
        {
        }

        public DbSet<BikeShop> BikeShops { get; set; }

        public DbSet<BikeShop_GoodCategory> BikeShop_GoodCategorys { get; set; }

        public DbSet<BikeShop_Good> BikeShop_Goods { get; set; }
        //public DbSet<BikeShop_Good_Z3950Target_SupportedProfile> BikeShop_Good_Z3950Target_SupportedProfiles { get; set; }
        //public DbSet<BikeShop_Good_Z3950Target_Authentication> BikeShop_Good_Z3950Target_Authentications { get; set; }

        //public DbSet<BikeShop_Good_Z3950Target_DatabaseName> BikeShop_Good_Z3950Target_DatabaseNames { get; set; }
        //public DbSet<BikeShop_Good_Z3950Target_PreferredRecordSyntax> BikeShop_Good_Z3950Target_PreferredRecordSyntaxes { get; set; }

        //public DbSet<BikeShop_Good_Z3950Target_Dns_PortNumber> BikeShop_Good_Z3950Target_Dns_PortNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BikeShop__Mapping());


            modelBuilder.ApplyConfiguration(new BikeShop_GoodCategory__Mapping());
            modelBuilder.ApplyConfiguration(new BikeShop_GoodCategory_Root__Mapping());
            modelBuilder.ApplyConfiguration(new BikeShop_GoodCategory_NonRoot__Mapping());

            modelBuilder.ApplyConfiguration(new BikeShop_BibliographicalRecordInventory__Mapping());

            modelBuilder.ApplyConfiguration(new BikeShop_Good__Mapping());
            modelBuilder.ApplyConfiguration(new BikeShop_Good_Z3950Target__Mapping());

            #region BikeShop
            modelBuilder.ApplyConfiguration(new BikeShop_Good__Local__BikeShop__Mapping());
            modelBuilder.ApplyConfiguration(new BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory__Mapping());
            #endregion
        }
    }
}
