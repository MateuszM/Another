using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningASPCORE.Models;
using LearningASPCORE.ViewModel;
using LearningASPCORE.Data;

namespace LearningASPCORE.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController(ApplicationDbContext db)
        {
            _context = db;
          //  SeedData(_context);
        }
        public IActionResult Index()
        {

            return View();
            
        }

        public void SeedData(ApplicationDbContext db)
        {

            DiaryModel p = new DiaryModel();
            DiaryModel d = new DiaryModel();
            ApplicationUser s = db.Users.FirstOrDefault();
            p.DiaryTitle = "FunnyOne";
            IList<PageModel> Pages = new List<PageModel>() { new PageModel { ContentPage = "Coś Się kończy coś się zaczyna jak się skończyło to koniec", IsChanged = false, PageTitle = "My Diary Seed", Registration = new DateTime(2008, 3, 9, 16, 5, 7, 123) },
                                                 new PageModel { ContentPage = "A moze nie ma tragedii? Czy jednak jest ?!", IsChanged = false, PageTitle = "Rozdzial Pierwszy I nie Pierwszy", Registration = new DateTime(2009, 3, 9, 16, 5, 7, 123) },};
            IList<PageModel> Pases2 = new List<PageModel>() { new PageModel { ContentPage = "Coś Jednak jest na rzeczy ale czy koniecznie ?", IsChanged = false, PageTitle = "Tak To działa ", Registration = new DateTime(2010, 3, 9, 16, 5, 7, 123) },
                                                 new PageModel {ContentPage = "Koniec nie ma juz nic i jesteśmy wolni", IsChanged = false, PageTitle = ".... Za mało kropek ?", Registration = new DateTime(2012, 3, 9, 16, 5, 7, 123) }, };
            p.DiaryTitle = "No Diary To Diary";
            
            p.Pages = Pages;
          
            d.DiaryTitle = "Dziala to dziala po co drązyć?";
            d.Pages = Pases2;
            p.AplicationUser = s;
            d.AplicationUser = s;
            IList<DiaryModel> diar = new List<DiaryModel>();
            diar.Add(p);
            diar.Add(d);
            s.Diarys = diar;
            db.Add(p);
            db.Add(d);
            db.Update(s);
            db.SaveChanges();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
