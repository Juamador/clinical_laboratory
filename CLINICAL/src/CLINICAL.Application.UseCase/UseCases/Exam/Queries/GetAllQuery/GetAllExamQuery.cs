using CLINICAL.Application.DTOs.Exam.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllExamQuery: IRequest<BasePaginationResponse<IEnumerable<GetallExamResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
