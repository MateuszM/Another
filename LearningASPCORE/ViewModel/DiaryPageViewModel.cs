using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningASPCORE.Models;
namespace LearningASPCORE.ViewModel
{
    public class DiaryPageViewModel
    {
        public int CurrentPage  { get; set; }
        public PageModel Diary { get; set; }
        public bool CanChangePage { get; set; }
    }
}
