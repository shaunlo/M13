using M13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace M13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }
        private ITeamRepository _repoteam { get; set; }
        public HomeController(IBowlersRepository temp, ITeamRepository tempteam)
        {
            _repo = temp;
            _repoteam = tempteam;
        }

        public IActionResult Index(string teamName)
        {
            var blah = _repo.Bowlers
                .Include("Team")
                .Where(b => b.Team.TeamName == teamName || teamName == null)
                .ToList();
            ViewData["TeamName"] = teamName;
            return View(blah);
        }
    }
}
