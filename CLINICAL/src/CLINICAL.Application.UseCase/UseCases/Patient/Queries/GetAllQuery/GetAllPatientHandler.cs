using CLINICAL.Application.DTOs.Patient.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GetAllPatientHandler : IRequestHandler<GeAllPatientQuery, BasePaginationResponse<IEnumerable<GetAllPatientResponseDTo>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllPatientResponseDTo>>> Handle(GeAllPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllPatientResponseDTo>>();

            try
            {
                var count = await _unitOfWork.Patient.CountAsync(TB.Patients);
                var patients = await _unitOfWork.Patient.GetAllPatients(SP.SP_GET_PATIENT_LIST, request);

                if(patients is not null)
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count * (double)request.PageSize);
                    response.TotalCount = count;
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
