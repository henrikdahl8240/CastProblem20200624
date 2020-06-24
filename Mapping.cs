using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastProblem20200624
{
    internal abstract class OLCEntityTypeConfiguration<TEntityType> : IEntityTypeConfiguration<TEntityType>
        where TEntityType : class, IID_Version
    {
        public virtual void Configure(EntityTypeBuilder<TEntityType> builder)
        {
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.Version).IsRowVersion();
        }
    }

    internal class BikeShop__Mapping : OLCEntityTypeConfiguration<BikeShop>
    {
        public BikeShop__Mapping()
        {
        }

        public override void Configure(EntityTypeBuilder<BikeShop> builder)
        {
            base.Configure(builder);

            builder.ToTable("BikeShops");
        }
    }

    internal class BikeShop_GoodCategory__Mapping : OLCEntityTypeConfiguration<BikeShop_GoodCategory>
    {
        public BikeShop_GoodCategory__Mapping()
        {
        }

        public override void Configure(EntityTypeBuilder<BikeShop_GoodCategory> builder)
        {
            base.Configure(builder);

            builder.ToTable("BikeShop_GoodCategorys");

            builder.HasDiscriminator<Byte>("Discriminator")
                .HasValue<BikeShop_GoodCategory_Root>((Byte)BikeShop_GoodCategory_Root.DiscriminatorValue)
                .HasValue<BikeShop_GoodCategory_NonRoot>((Byte)BikeShop_GoodCategory_NonRoot.DiscriminatorValue);
        }
    }

    internal class BikeShop_GoodCategory_Root__Mapping : IEntityTypeConfiguration<BikeShop_GoodCategory_Root>
    {
        public void Configure(EntityTypeBuilder<BikeShop_GoodCategory_Root> builder)
        {
        }
    }

    internal class BikeShop_GoodCategory_NonRoot__Mapping : IEntityTypeConfiguration<BikeShop_GoodCategory_NonRoot>
    {
        public void Configure(EntityTypeBuilder<BikeShop_GoodCategory_NonRoot> builder)
        {
            builder.HasOne(t => t.CategoryParent)
                .WithMany(t => t.CategoryChildren)
                .HasForeignKey(d => d.CategoryParentID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class BikeShop_BibliographicalRecordInventory__Mapping : OLCEntityTypeConfiguration<BikeShop_BibliographicalRecordInventory>
    {
        public BikeShop_BibliographicalRecordInventory__Mapping()
        {
        }

        public override void Configure(EntityTypeBuilder<BikeShop_BibliographicalRecordInventory> builder)
        {
            base.Configure(builder);

            builder.ToTable("BikeShop_BibliographicalRecordInventories");
        }
    }

    internal class BikeShop_Good__Mapping : OLCEntityTypeConfiguration<BikeShop_Good>
    {
        public BikeShop_Good__Mapping()
        {
        }

        public override void Configure(EntityTypeBuilder<BikeShop_Good> builder)
        {
            base.Configure(builder);

            builder.ToTable("BikeShop_Goods");

            builder.HasDiscriminator<Byte>("Discriminator")
                .HasValue<BikeShop_Good_Z3950Target>((Byte)BikeShop_Good_Z3950Target.DiscriminatorValue)
                .HasValue<BikeShop_Good__Local__BikeShop>((Byte)BikeShop_Good__Local__BikeShop.DiscriminatorValue)
                .HasValue<BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory>((Byte)BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory.DiscriminatorValue)
                ;

            builder.HasOne(t => t.BikeShop)
                .WithMany(t => t.Goods)
                .HasForeignKey(d => d.BikeShopID)
                    .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Category)
                .WithMany(t => t.Contents)
                .HasForeignKey(d => d.CategoryID)
                    .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class BikeShop_Good_Z3950Target__Mapping : IEntityTypeConfiguration<BikeShop_Good_Z3950Target>
    {
        public void Configure(EntityTypeBuilder<BikeShop_Good_Z3950Target> builder)
        {
        }
    }

    #region BikeShop
    internal class BikeShop_Good__Local__BikeShop__Mapping : IEntityTypeConfiguration<BikeShop_Good__Local__BikeShop>
    {
        public void Configure(EntityTypeBuilder<BikeShop_Good__Local__BikeShop> builder)
        {
            builder.HasOne(t => t.Target_BikeShop)
                .WithMany(t => t.BikeShop_Goods)
                .HasForeignKey(d => d.Target_BikeShopID)
                    .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory__Mapping : IEntityTypeConfiguration<BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory>
    {
        public void Configure(EntityTypeBuilder<BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory> builder)
        {
            builder.HasOne(t => t.Target_BikeShop_BibliographicalRecordInventory)
                .WithMany(t => t.BikeShop_Goods)
                .HasForeignKey(d => d.Target_BikeShop_BibliographicalRecordInventoryID)
                    .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
    #endregion
}
