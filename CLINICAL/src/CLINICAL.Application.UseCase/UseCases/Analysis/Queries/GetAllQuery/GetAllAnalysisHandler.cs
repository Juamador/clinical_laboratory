using AutoMapper;
using CLINICAL.Application.DTOs.Analysis.Response;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commonds.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public GetAllAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>();

            try
            {
                var analysis = await _analysisRepository.ListAnalysis();
                if(analysis is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDto>>(analysis);
                    response.Message = "Success query!!!";
                    
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
