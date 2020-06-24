using Microsoft.AspNet.OData.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastProblem20200624
{
    public class HDODataConventionModelBuilder : ODataConventionModelBuilder
    {
        public HDODataConventionModelBuilder()
        {
            this.EntityType<BikeShop>().Expand(100).Select().Filter();

            this.EntityType<BikeShop_GoodCategory>().Expand(100).Select().Filter();
            this.EntityType<BikeShop_GoodCategory_Root>().Expand(100).Select().Filter();
            this.EntityType<BikeShop_GoodCategory_NonRoot>().Expand(100).Select().Filter();

            this.EntityType<BikeShop_Good>().Expand(100).Select().Filter();
            this.EntityType<BikeShop_Good_Z3950Target>().Expand(100).Select().Filter();
            this.EntityType<BikeShop_Good__Local>().Expand(100).Select().Filter();
            this.EntityType<BikeShop_Good__Local__BikeShop>().Expand(100).Select().Filter();
            this.EntityType<BikeShop_Good__Local__BikeShop_BibliographicalRecordInventory>().Expand(100).Select().Filter();

            this.EntityType<BikeShop_BibliographicalRecordInventory>().Expand(100).Select().Filter();

            this.EntitySet<BikeShop_GoodCategory>("BikeShop_GoodCategorys");
        }
    }
}
