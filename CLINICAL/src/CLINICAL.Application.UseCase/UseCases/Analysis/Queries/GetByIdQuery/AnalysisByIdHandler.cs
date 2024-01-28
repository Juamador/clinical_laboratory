using AutoMapper;
using CLINICAL.Application.DTOs.Analysis.Response;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;
        public AnalysisByIdHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdResponseDto>();

            try
            {
                var analysis = await _analysisRepository.AnalysisById(request.AnalysisId);
                if(analysis is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No records found";
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
                response.Message = "Success Request!!!";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
