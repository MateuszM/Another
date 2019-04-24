using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LearningASPCORE.Models;

namespace LearningASPCORE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DiaryModel> Diary { get; set; }
        public DbSet<PageModel> Pages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PageModel>().HasData(new PageModel { Id = 1, ContentPage = "Coś Się kończy coś się zaczyna", IsChanged = false, PageTitle = "My Diary", Registration = new DateTime(2008, 3, 9, 16, 5, 7, 123) },
                                                 new PageModel { Id = 2, ContentPage = "A moze nie ma tragedii?", IsChanged = false, PageTitle = "Rozdzial Pierwszy", Registration = new DateTime(2009, 3, 9, 16, 5, 7, 123) },
                                                 new PageModel { Id = 3, ContentPage = "Coś Jednak jest na rzeczy", IsChanged = false, PageTitle = "     ", Registration = new DateTime(2010, 3, 9, 16, 5, 7, 123) },
                                                 new PageModel { Id = 4, ContentPage = "Koniec nie ma juz nic", IsChanged = false, PageTitle = "....", Registration = new DateTime(2012, 3, 9, 16, 5, 7, 123) });
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
