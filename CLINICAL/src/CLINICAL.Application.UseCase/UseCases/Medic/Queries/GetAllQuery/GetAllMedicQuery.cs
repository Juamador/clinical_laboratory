using CLINICAL.Application.DTOs.Medic;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery
{
    public class GetAllMedicQuery: IRequest<BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
