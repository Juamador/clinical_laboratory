using CLINICAL.Application.DTOs.Patient.Response;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery
{
    public class GetPatientByIdQuery: IRequest<BaseResponse<GetPatientByIdResponseDto>>
    {
        public int PatientId { get; set; }
    }
}
