using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsBaseAPI.Common.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [Display(Name = "Date of Entry")]
        public DateTime DateOfEntry { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Place of birth")]
        public string PlaceOfBirth { get; set; }

        //[Display(Name = "Grades of Courses")]
        //public List<(string, short, int)> GradesOfCourses { get; set; }

        //public List<(string, string)> CoursesProfessors { get; set; }
      
        [Display(Name = "Grade average")]
        public double GradeAverage { get; set; }

    }
}
