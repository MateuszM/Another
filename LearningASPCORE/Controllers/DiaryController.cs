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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningASPCORE.Controllers
{
    public class DiaryController : Controller
    {
        private readonly ApplicationDbContext _context;

  
        
        private const int DefaultPageSize = 10;
        private IList<DiaryModel> allProducts = new List<DiaryModel>();

        public DiaryController(ApplicationDbContext context)
        {
            _context = context;
        }
        private void InitializeDiary()
        {
            
        }
        public async Task<ActionResult> About()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Diary()
        {
            ViewData["Message"] = "My Diary";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
