using CLINICAL.Application.DTOs.Analysis.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class GetAnalysisByIdQuery: IRequest<BaseResponse<GetAnalysisByIdResponseDto>>
    {
        public int AnalysisId { get; set; }
    }
}
