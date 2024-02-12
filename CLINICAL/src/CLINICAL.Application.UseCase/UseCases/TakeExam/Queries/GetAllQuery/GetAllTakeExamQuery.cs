
using CLINICAL.Application.DTOs.TakeExam.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery
{
    public class GetAllTakeExamQuery: IRequest<BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
