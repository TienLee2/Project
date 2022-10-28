using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PagedList.Core;
using PRN_Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // cái này của product
        private readonly SWP_DB_FinalContext _context;
       
        public HomeController(SWP_DB_FinalContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 20;
                var lsProducts = _context.Products.AsNoTracking().OrderByDescending(x => x.Id);
                PagedList<Product> models = new PagedList<Product>(lsProducts, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }
           
        }


        [Route("/{Name}-{Id}.html", Name = "ProductDetails")]
        public IActionResult Details(int Id)
        {
            try
            {
                var product = _context.Products.Include(x => x.Cate).FirstOrDefault(x => x.Id == Id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
            
        }


        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
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
