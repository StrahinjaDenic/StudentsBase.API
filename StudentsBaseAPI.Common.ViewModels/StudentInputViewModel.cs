using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsBaseAPI.Common.ViewModels
{
    public class StudentInputViewModel : IValidatableObject
    {
        public int? Id { get; set; }

        public int? Index { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [Display(Name = "Date of entry")]
        public DateTime DateOfEntry { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Place of birth")]
        public string PlaceOfBirth { get; set; }

        public List<int> CoAndPrIds { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Index == null)
            {
                yield return new ValidationResult("Index is required!", new[] { nameof(Index) });
            }
            else if (Index <= 0)
            {
                yield return new ValidationResult("Index must be greater than 0!", new[] { nameof(Index) });
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("Name is required!", new[] { nameof(Name) });
            }
            if (string.IsNullOrWhiteSpace(Surname))
            {
                yield return new ValidationResult("Surname is required!", new[] { nameof(Surname) });
            }
            if (CoAndPrIds == null || CoAndPrIds.Count == 0)
            {
                yield return new ValidationResult("Professsor - Course is required!", new[] { nameof(CoAndPrIds) });
            }
        }
    }
}
