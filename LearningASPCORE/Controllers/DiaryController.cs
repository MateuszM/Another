using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningASPCORE.Models;
using LearningASPCORE.Repository;

namespace LearningASPCORE.Controllers
{
    public class DiaryController : Controller
    {
        private IEnumerable<PageModel> pages;
        public IEnumerable<PageModel> Pages { get { return pages; } set { pages = value; } }
        private IEnumerable<DiaryModel> diarys;
        private IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } set { _unitOfWork = value; } }

        public DiaryController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            
        }
        public IActionResult Diary()
        {
            return View(UnitOfWork.Repository<DiaryModel>().GetAllAsync().Result);
        }

    }
}
