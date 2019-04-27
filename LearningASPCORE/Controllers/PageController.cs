using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningASPCORE.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using LearningASPCORE.Data;
using Microsoft.EntityFrameworkCore;
using LearningASPCORE.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningASPCORE.Controllers
{
    [Route("[controller]/[action]")]
    public class PageController : Controller
    {
        private readonly ApplicationDbContext _context;

        private PageModel page;
        public PageModel Page { get { return page; } set { page = value; } }
     
        

        public PageController(ApplicationDbContext context)
        {
            _context = context;
            InitializePage();
        }
        private void InitializePage()
        {
          //  allPages = About().Result.;
           
        }
        public async Task<IList<DiaryModel>> About()
        {
            return null;
        }
       [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetPage(int page)
        {
            /*
            if(page < 0 )
            {
                return RedirectToAction("PageDoesNotExist");
            }
            ViewData["Message"] = page.ToString();
            var view = new DiaryPageViewModel();
            view.CanChangePage = true;
            if (page == .Count)
            {
                view.CanChangePage = false;
                AllPages.Add(new PageModel());
            }

            view.CurrentPage = page;
            view.Diary = AllPages[view.CurrentPage];
            return View(view);
            */
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiaryPageViewModel DiaryView)
        {
          


            return RedirectToAction("Diary");
        }
        public IActionResult PageDoesNotExist()
        {
            ModelState.AddModelError("Error", "Page Does Not Exist");
            return View();
        }

        
        [HttpGet]
        public IActionResult GetNextPage(int diary)
        {
            diary++;
            return RedirectToAction("Diary",new { page = diary});
        }
        [HttpGet]
       public IActionResult GetPreviousPage(int diary)
        {
            diary--;
            return RedirectToAction("Diary", new { page = diary });
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
