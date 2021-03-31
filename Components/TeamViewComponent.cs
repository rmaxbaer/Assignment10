using Microsoft.AspNetCore.Mvc;
using Assignment10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamViewComponent (BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            //The value is determined by the route, which we set up in Startup endpoints
            //This stores the selected team so that we can highlight the current link
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];

            return View(context.Teams
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
