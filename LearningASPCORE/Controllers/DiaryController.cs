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
    public class DiaryController : Controller
    {
        private readonly ApplicationDbContext _context;

 
        
     
        private IList<DiaryModel> allPages = new List<DiaryModel>();
        public IList<DiaryModel> AllPages { get { return allPages; } set { allPages = value; } }
     
        

        public DiaryController(ApplicationDbContext context)
        {
            _context = context;
            InitializeDiary();
        }
        private void InitializeDiary()
        {
            allPages = About().Result;
           
        }
        public async Task<IList<DiaryModel>> About()
        {
             return await _context.Diary.ToListAsync(); 
        }
       [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Diary(int page)
        {
            if(page < 0 )
            {
                return RedirectToAction("PageDoesNotExist");
            }
            ViewData["Message"] = page.ToString();
            var view = new DiaryViewModel();
            view.CanChangePage = true;
            if (page == AllPages.Count)
            {
                view.CanChangePage = false;
                AllPages.Add(new DiaryModel());
            }

            view.CurrentPage = page;
            view.Diary = AllPages[view.CurrentPage];
            return View(view);
        }
        [HttpPost]
        public IActionResult Create(DiaryViewModel DiaryView)
        {
            AllPages[DiaryView.CurrentPage] = DiaryView.Diary;


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
