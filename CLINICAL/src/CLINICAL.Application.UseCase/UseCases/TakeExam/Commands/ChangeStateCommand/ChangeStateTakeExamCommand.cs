using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand
{
    public class ChangeStateTakeExamCommand: IRequest<BaseResponse<bool>>
    {
        public int TakeExamId { get; set; }
        public int State { get; set; }
    }
}
