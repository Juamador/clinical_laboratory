using CLINICAL.Application.DTOs.Patient.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GeAllPatientQuery: IRequest<BaseResponse<IEnumerable<GetAllPatientResponseDTo>>>
    {
    }
}
