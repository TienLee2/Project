using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN_Project.Models;

namespace PRN_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillsController : Controller
    {
        private readonly SWP_DB_FinalContext _context;

        public BillsController(SWP_DB_FinalContext context)
        {
            _context = context;
        }

        // GET: Admin/Bills
        public async Task<IActionResult> Index()
        {
            var sWP_DB_FinalContext = _context.Bills.Include(b => b.IdAccountNavigation);
            return View(await sWP_DB_FinalContext.ToListAsync());
        }

        // GET: Admin/Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.IdAccountNavigation)
                .FirstOrDefaultAsync(m => m.BillId == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

       
    }
}
