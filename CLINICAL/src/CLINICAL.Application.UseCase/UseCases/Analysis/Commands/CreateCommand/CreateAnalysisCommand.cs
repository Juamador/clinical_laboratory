using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisCommand: IRequest<BaseResponse<bool>>
    {
        public string? Name {  get; set; }
    }
}
