using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisCommand: IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
    }
}
