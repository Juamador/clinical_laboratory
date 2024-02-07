using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.UpdateCommand
{
    public class UpdateExamHandleer : IRequestHandler<UpdateExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateExamHandleer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var exam = _mapper.Map<Entity.Exam>(request);
                var parameters = exam.GetPropiertiesWithValues();
                response.Data = await _unitOfWork.Exam.ExcecAsync(SP.SP_EXAM_EDIT, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGES_UPDATE;
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
