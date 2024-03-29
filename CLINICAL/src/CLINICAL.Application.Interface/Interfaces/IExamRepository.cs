﻿using CLINICAL.Application.DTOs.Exam.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IExamRepository: IGenericRepository<Exam>
    {
        Task<IEnumerable<GetallExamResponseDto>> GetAllExams(string StoredProcedure, object parameter);
    }
}
