using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsBaseAPI.Common.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short Points { get; set; }
    }
}
