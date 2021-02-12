using DiziApp.WEBUI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiziApp.WEBUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly SerieContext _context;
        public CategoriesViewComponent(SerieContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            return View(_context.Categories.ToList());
        }
    }
}
