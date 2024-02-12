using CLINICAL.Application.DTOs.Patient.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GeAllPatientQuery: IRequest<BasePaginationResponse<IEnumerable<GetAllPatientResponseDTo>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
