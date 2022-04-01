using System.Collections.Generic;

namespace StudentsBaseAPI.Common.ViewModels
{
    public class ProfessorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<string> CourseNames { get; set; }
    }
}
