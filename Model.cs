using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CastProblem20200624
{
    public interface IID_Version
    {
        Guid ID { get; }
        byte[] Version { get; }
    }


    #region Category for BikeShop
    internal enum BikeShop_GoodCategory__DiscriminatorKind
    {
        BikeShop_GoodCategory_Root = 0,
        BikeShop_GoodCategory_NonRoot = 1
    }

    public abstract class BikeShop_GoodCategory: IID_Version
    {
        public Guid ID { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }

        public virtual ICollection<BikeShop_GoodCategory_NonRoot> CategoryChildren { get; set; }

        public virtual ICollection<BikeShop_Good> Contents { get; set; }
    }

    public class BikeShop_GoodCategory_Root : BikeShop_GoodCategory
    {
        internal static BikeShop_GoodCategory__DiscriminatorKind DiscriminatorValue => BikeShop_GoodCategory__DiscriminatorKind.BikeShop_GoodCategory_Root;

        public Guid BikeShopID { get; set; }
        public virtual BikeShop BikeShop { get; set; }
    }

    public class BikeShop_GoodCategory_NonRoot : BikeShop_GoodCategory
    {
        internal static BikeShop_GoodCategory__DiscriminatorKind DiscriminatorValue => BikeShop_GoodCategory__DiscriminatorKind.BikeShop_GoodCategory_NonRoot;

        public Guid CategoryParentID { get; set; }
        public virtual BikeShop_GoodCategory CategoryParent { get; set; }
    }
    #endregion

    internal enum BikeShop_Good__DiscriminatorKind
    {
        BikeShop_Good_Z3950Target = 0,
        BikeShop_Good__Local__BikeShop = 7,
        BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory = 8
    }

    public abstract class BikeShop_Good : IID_Version
    {
        public Guid ID { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }

        public Guid CategoryID { get; set; }
        public virtual BikeShop_GoodCategory Category { get; set; }

        public Guid BikeShopID { get; set; }
        public virtual BikeShop BikeShop { get; set; }
    }

    public class BikeShop_Good_Z3950Target : BikeShop_Good
    {
        internal static BikeShop_Good__DiscriminatorKind DiscriminatorValue => BikeShop_Good__DiscriminatorKind.BikeShop_Good_Z3950Target;

        public string ISIL_Number { set; get; }
    }

    public abstract class BikeShop_Good__Local : BikeShop_Good
    {
        [Url]
        [MaxLength(200)]
        public string Preferred_PropertyUri_For_BibliographicalRecord { get; set; }
    }

    #region BikeShop
    public partial class BikeShop : IID_Version
    {
        public Guid ID { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }

        public virtual ICollection<BikeShop_GoodCategory_Root> GoodCategory_Roots { get; set; }
        public virtual ICollection<BikeShop_Good> Goods { get; set; }

        public virtual ICollection<BikeShop_Good__Local__BikeShop> BikeShop_Goods { get; set; }
    }

    public class BikeShop_Good__Local__BikeShop : BikeShop_Good__Local
    {
        internal static BikeShop_Good__DiscriminatorKind DiscriminatorValue => BikeShop_Good__DiscriminatorKind.BikeShop_Good__Local__BikeShop;

        public Guid Target_BikeShopID { get; set; }
        public virtual BikeShop Target_BikeShop { get; set; }
    }

    public partial class BikeShop_BibliographicalRecordInventory : IID_Version
    {
        public Guid ID { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }

        public virtual ICollection<BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory> BikeShop_Goods { get; set; }
    }

    public class BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory : BikeShop_Good__Local
    {
        internal static BikeShop_Good__DiscriminatorKind DiscriminatorValue => BikeShop_Good__DiscriminatorKind.BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory;

        public Guid Target_BikeShop_BibliographicalRecordInventoryID { get; set; }
        public virtual BikeShop_BibliographicalRecordInventory Target_BikeShop_BibliographicalRecordInventory { get; set; }
    }
    #endregion
}
