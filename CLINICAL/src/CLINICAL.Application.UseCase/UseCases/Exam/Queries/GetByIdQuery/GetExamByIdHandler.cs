using AutoMapper;
using CLINICAL.Application.DTOs.Exam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery
{
    public class GetExamByIdHandler : IRequestHandler<GetExamByIdQuery, BaseResponse<GetExamByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task <BaseResponse<GetExamByIdResponseDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetExamByIdResponseDto>();

            try
            {
                var exam = await _unitOfWork.Exam.GetByIdAsync(SP.SP_GET_EXAM_BY_ID, request);

                if(exam is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGES_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetExamByIdResponseDto>(exam);
                response.Message = GlobalMessages.MESSAGES_QUERY;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
