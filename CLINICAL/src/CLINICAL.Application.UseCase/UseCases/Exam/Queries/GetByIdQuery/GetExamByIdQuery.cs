using CLINICAL.Application.DTOs.Exam.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery
{
    public class GetExamByIdQuery: IRequest<BaseResponse<GetExamByIdResponseDto>>
    {
        public int ExamId { get; set; }
    }
}
