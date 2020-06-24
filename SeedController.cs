using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastProblem20200624
{
    [ApiController]
    [Route("[controller]")]
    public class SeedController : ControllerBase
    {
        public SeedController(CastProblemDbContext castProblemDbContext)
        {
            CastProblemDbContext = castProblemDbContext;
        }

        private CastProblemDbContext CastProblemDbContext { set; get; }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var bikeShop = new BikeShop();
            CastProblemDbContext.BikeShops.Add(bikeShop);

            var bikeShop_GoodCategory_Root = new BikeShop_GoodCategory_Root() { };

            bikeShop.GoodCategory_Roots = new HashSet<BikeShop_GoodCategory_Root>() { bikeShop_GoodCategory_Root };

            var bikeShop_GoodCategory_NonRoot = new BikeShop_GoodCategory_NonRoot() { };
            bikeShop_GoodCategory_Root.CategoryChildren = new HashSet<BikeShop_GoodCategory_NonRoot>() { bikeShop_GoodCategory_NonRoot };

            var bikeShop_Good_Z3950Target1 = new BikeShop_Good_Z3950Target() { ISIL_Number = "C" };
            bikeShop_GoodCategory_NonRoot.Contents = new HashSet<BikeShop_Good>() { bikeShop_Good_Z3950Target1 };
            bikeShop.Goods = new HashSet<BikeShop_Good>() { bikeShop_Good_Z3950Target1 };

            await CastProblemDbContext.SaveChangesAsync();

            return base.Ok("Seeding Complete");
        }
    }
}
