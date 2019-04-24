using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningASPCORE.Models
{
    public class PageModel
    { 
        public int Id { get; set; }
        public String PageTitle { get; set; }
        public String ContentPage { get; set; }
        public DateTime Registration { get; set; }
        public bool IsChanged { get; set; }
    }
}
