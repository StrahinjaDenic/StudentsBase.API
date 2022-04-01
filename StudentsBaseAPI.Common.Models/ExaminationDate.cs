using System.Collections.Generic;

namespace StudentsBaseAPI.Common.Models
{
    public class ExaminationDate
    {
        public ExaminationDate()
        {
            Exams = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public short Year { get; set; }
        public string Mark { get; set; }
        public string Name { get; set; }

        #region Navigation properties

        public virtual ICollection<Exam> Exams { get; set; }

        #endregion
    }
}
