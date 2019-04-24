using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningASPCORE.Models;

namespace LearningASPCORE.Controllers
{
    public class DiaryController : Controller
    {
        private IEnumerable<PageModel> pages;
        public IEnumerable<PageModel> Pages { get { return pages; } set { pages = value; } }

        public IActionResult ShowPages()
        {
            return View();
        }

    }
}
