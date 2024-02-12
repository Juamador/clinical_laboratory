using CLINICAL.Application.DTOs.TakeExam.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetByIdQuery
{
    public class GetTakeExamByIdQuery: IRequest<BaseResponse<GetTakeExamByIdResponseDto>>
    {
        public int TakeExamId { get; set; }
    }
}
