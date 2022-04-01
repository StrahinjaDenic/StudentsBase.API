using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsBaseAPI.Common.ViewModels
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        public int Index { get; set; }

        [Display(Name = "Course name")]
        public string CourseName { get; set; }

        [Display(Name = "Examination year")]
        public short Year { get; set; }

        [Display(Name = "Examination mark")]
        public string Mark { get; set; }

        public short Grade { get; set; }

        [Display(Name = "Exam date")]
        public DateTime? ExamDate { get; set; }

        public short? Points { get; set; }
    }
}
