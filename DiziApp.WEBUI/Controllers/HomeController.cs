using DiziApp.WEBUI.Data;
using DiziApp.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiziApp.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly SerieContext _context;
        public HomeController(SerieContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var m = new HomeViewModel
            {
                PopularSeries = _context.Series.ToList()
            };
            
            return View(m);
        }
        
        public IActionResult About()
        {
            return View();
        }

    }
}
