using CLINICAL.Application.DTOs.Patient.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GetAllPatientHandler : IRequestHandler<GeAllPatientQuery, BaseResponse<IEnumerable<GetAllPatientResponseDTo>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllPatientResponseDTo>>> Handle(GeAllPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllPatientResponseDTo>>();

            try
            {
                var patients = await _unitOfWork.Patient.GetAllPatients(SP.SP_GET_PATIENT_LIST);

                if(patients is not null)
                {
                    response.IsSuccess = true;
                    response.Data = patients;
                    response.Message = GlobalMessages.MESSAGES_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
