using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsBaseAPI.Common.ViewModels
{
    public class ExaminationDateInputViewModel
    {
        public int? Id { get; set; }

        public short? Year { get; set; }

        public string Mark { get; set; }

        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("Name is required!", new[] { nameof(Name) });
            }
            if (string.IsNullOrWhiteSpace(Mark))
            {
                yield return new ValidationResult("Mark is required!", new[] { nameof(Mark) });
            }
            if (Year == null)
            {
                yield return new ValidationResult("Year is required!", new[] { nameof(Year) });
            }
            else if (Year <= 0)
            {
                yield return new ValidationResult("Year is invalid!", new[] { nameof(Year) });
            }
        }
    }
}
