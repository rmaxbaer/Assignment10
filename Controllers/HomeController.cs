using Assignment10.Models;
using Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(long? teamId, string team, int pageNum = 0)
        {
            int pageSize = 5;
            // int pageNum = 1;

            return View(new IndexViewModel
            {
                Bowlers = context.Bowlers
                .Where(x => x.TeamId == teamId || teamId == null)
                .OrderBy(x => x.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    // if no team is selected, count all bowlers, otherwise count that team's bowlers
                    TotalNumItems = (teamId == null ? context.Bowlers.Count() :
                    context.Bowlers.Where(x => x.TeamId == teamId).Count())
                },

                //Team = team
                Team = context.Teams
                .Where(x => x.TeamId == teamId).FirstOrDefault()
            });
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
