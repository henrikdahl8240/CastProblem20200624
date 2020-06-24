using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastProblem20200624
{
    public partial class BikeShop_GoodCategorysController : ODataController
    {
        public BikeShop_GoodCategorysController(CastProblemDbContext castProblemDbContext)
        {
            this.CastProblemDbContext = castProblemDbContext;
        }

        CastProblemDbContext CastProblemDbContext;

        [EnableQuery(MaxExpansionDepth = 100, MaxAnyAllExpressionDepth = 2)]
        public ActionResult<IQueryable<BikeShop_GoodCategory_NonRoot>> GetFromBikeShop_GoodCategory_NonRoot(ODataQueryOptions<BikeShop_GoodCategory_NonRoot> queryOptions)
        {
            return Ok(CastProblemDbContext.BikeShop_GoodCategorys.OfType<BikeShop_GoodCategory_NonRoot>());
        }
    }
}
