using System;
using System.Collections.Generic;

namespace LearningASPCORE.Models
{
    public class DiaryModel
    {
        public int Id { get; set; }
        public String DiaryTitle { get; set; }
        public virtual IList<PageModel> Pages { get; set; }
        public virtual ApplicationUser AplicationUser { get; set; }

    }
}
