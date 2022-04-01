﻿using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsBaseAPI.IBusinessLogic
{
    public interface IExaminationDateBL
    {
        Task<List<ExaminationDateViewModel>> GetAllExaminationDatesFilteredAsync(int? year, string name = null);

        Task<ValidationResponse> CreateOrEditAsync(ExaminationDateInputViewModel model);

        Task<ExaminationDate> GetFirstExaminationDateAsync(int examinationDateId);

        Task<bool> DeleteExaminationDateAsync(int examinationDateId);
    }
}