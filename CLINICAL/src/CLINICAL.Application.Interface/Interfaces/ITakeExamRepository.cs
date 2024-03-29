﻿using CLINICAL.Application.DTOs.TakeExam.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface ITakeExamRepository: IGenericRepository<TakeExam>
    {
        Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExam(string storedProcedure, object parameter);
        Task<TakeExam> GetTakeExamById(int takeExamId);
        Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId);
    }
}
