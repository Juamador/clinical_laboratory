using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Command.ChangePatientState
{
    public class ChangeStatePatientCommand: IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
        public int State { get; set; }
    }
}
