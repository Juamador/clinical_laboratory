using CLINICAL.Application.DTOs.Medic;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery
{
    public class GetAllMedicQuery: IRequest<BaseResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
    }
}
