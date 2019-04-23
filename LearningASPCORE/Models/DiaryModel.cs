using System;

namespace LearningASPCORE.Models
{
    public class DiaryModel
    {
        public int Id { get; set; }
        public String PageTitle { get; set; }
        public String ContentPage { get; set; }
        public DateTime Registration { get; set; }
        public bool IsChanged { get; set; }
    }
}
