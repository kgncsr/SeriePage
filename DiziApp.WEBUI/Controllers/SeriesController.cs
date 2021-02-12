using DiziApp.WEBUI.Data;
using DiziApp.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiziApp.WEBUI.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SerieContext _context;
        public SeriesController(SerieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(int? id,string q)
        {
            //var series = SerieRepository.Series;
            var series = _context.Series.AsQueryable();

            if(id != null)
            {
                series = series.Where(k => k.CategoryId == id);
            }

            if (!string.IsNullOrEmpty(q))
            {
                series = series.Where(i => i.Title.ToLower().Contains(q.ToLower()));
            }

            var model = new SeriesViewModel()
            {
                Series = series.ToList()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {

            return View(_context.Series.Find(id));
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Category = new SelectList(_context.Categories.ToList(), "CategoryId", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Serie d)
        {
            if (ModelState.IsValid)
            {
                //SerieRepository.Add(d);
                _context.Series.Add(d);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.Category = new SelectList(_context.Categories.ToList(), "CategoryId", "Name");
            return View();

         
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Category = new SelectList(_context.Categories.ToList(), "CategoryId", "Name");
            return View(_context.Series.Find(id));
        }

         
        [HttpPost]
        public IActionResult Edit(Serie m)
        {
            if (ModelState.IsValid)
            {
                //SerieRepository.Edit(m);
                _context.Series.Update(m);
                _context.SaveChanges();
                return RedirectToAction("Details", "Series", new { @id = m.SerieId });
            }

            ViewBag.Category = new SelectList(_context.Categories.ToList(), "CategoryId", "Name");
            return View(m);

        }


        public IActionResult Delete(int SerieId)
        {
            //SerieRepository.Delete(SerieId);
            var c = _context.Series.Find(SerieId);
            _context.Series.Remove(c);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
