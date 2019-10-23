using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MUDling.Models;

namespace MUDling.Controllers
{
    public class HomeController : Controller
    {
        private DungeonDB _context;
       
        private UserManager<AppUser> _userManager;

        //class constructor
        public HomeController(UserManager<AppUser> userManager, DungeonDB context)
        {
            _userManager = userManager;
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
        [HttpGet]
        public async Task<IActionResult> CreateDungeon()
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user.AppUserId;
            ViewBag.Id = id;
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> CreateDungeon(string name, string description)
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user.AppUserId;
            var dungeon = new Dungeon
            {
                Name = name,
                Description = description,
                AppUserId = id
            };
            _context.Add(dungeon);
            _context.SaveChanges();
            ViewBag.Name = name;
           
            ViewBag.Description = description;


            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
