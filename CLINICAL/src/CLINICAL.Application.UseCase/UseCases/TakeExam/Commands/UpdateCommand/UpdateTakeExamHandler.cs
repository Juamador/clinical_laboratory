using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Domain.Entities;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand
{
    public class UpdateTakeExamHandler : IRequestHandler<UpdateTakeExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateTakeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateTakeExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                var takeExam = _mapper.Map<Entity.TakeExam>(request);
                await _unitOfWork.TakeExam.EditTakeExam(takeExam);

                foreach (var detail in takeExam.TakeExamDetails)
                {
                    var editTakeExamDetail = new TakeExamDetail
                    {
                        ExamId = detail.ExamId,
                        AnalysisId = detail.AnalysisId,
                        TakeExamDetailId = detail.TakeExamDetailId
                    };

                    await _unitOfWork.TakeExam.EditTakeExamDetail(editTakeExamDetail);
                }

                transaction.Complete();
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGES_UPDATE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
