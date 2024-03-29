﻿using AutoMapper;
using CLINICAL.Application.DTOs.Analysis.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commonds.Bases;
using CLINICAL.Domain.Entities;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AnalysisByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdResponseDto>();

            try
            {
                var analysis = await _unitOfWork.Analysis.GetByIdAsync(SP.SP_GET_ANALYSIS_LIST_BY_ID, request);
                if(analysis is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGES_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
                response.Message = GlobalMessages.MESSAGES_QUERY;
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
