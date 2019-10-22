using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MUDling.Models;

namespace MUDling.Controllers
{
    public class HomeController : Controller
    {
        private DungeonDB _context;

        HomeController(DungeonDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateDungeon(string name, string description)
        {
            var dungeon = new Dungeon
            {
                Name = name,
                Description = description
            };
            _context.Add(dungeon);
            _context.SaveChanges();
            ViewBag.Name = name;
            ViewBag.Description = description;
            return View("CreateDungeon");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
