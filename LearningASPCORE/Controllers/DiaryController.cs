using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningASPCORE.Models;
using LearningASPCORE.Repository;
using NonFactors.Mvc.Grid;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View(UnitOfWork.Repository<DiaryModel>().GetIncludesAsync(x => x.Pages).Result);
        }
        
        public IActionResult PageDoesNotExist()
        {
            ModelState.AddModelError("Error", "Page Does Not Exist");
            return View();
        }
        private IGrid<DiaryModel> CreateExportableGrid()
        {
            IGrid<DiaryModel> grid = new Grid<DiaryModel>(UnitOfWork.Repository<DiaryModel>().GetIncludesAsync(x=>x.Pages).Result);
            grid.ViewContext = new ViewContext { HttpContext = HttpContext };
            grid.Query = Request.Query;

            grid.Columns.Add(model => model.DiaryTitle).Titled("Diary Title");
            grid.Columns.Add(model => model.Id).Titled("Id");

            grid.Columns.Add(model => model.AplicationUser).Titled("AplicationUser");
        

            grid.Pager = new GridPager<DiaryModel>(grid);
            grid.Processors.Add(grid.Pager);
            grid.Pager.RowsPerPage = 6;

            

            return grid;
        }
    }
}

