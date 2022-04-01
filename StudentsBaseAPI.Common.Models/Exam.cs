using System;

namespace StudentsBaseAPI.Common.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int ExaminationDateId { get; set; }
        public short Grade { get; set; }
        public DateTime? ExamDate { get; set; }
        public short? Points { get; set; }

        #region Navigation properties

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual ExaminationDate ExaminationDate { get; set; }

        #endregion
    }
}
